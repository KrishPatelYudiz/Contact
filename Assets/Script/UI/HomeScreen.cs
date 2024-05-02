using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class HomeScreen : BaseScreen
{
    [SerializeField] Button _addContactButton;
    [SerializeField] Button _LogoutButton;
    [SerializeField] GameObject _contactPreFab;
    [SerializeField] Transform _contactListParent;

    [SerializeField] Text NameTextFild;
    List<Contacts> contacts= new List<Contacts>();
    DataManager dataManager = new DataManager();

    
    private void Start()
    {
        _addContactButton.onClick.AddListener(OnAddContact);
        _LogoutButton.onClick.AddListener(OnLogout);
    }
    public override void ActivateScreen()
    {
        foreach(var contact in contacts){
            Destroy(contact.gameObject);
        }
        contacts.Clear(); 
        User user = UserData.user;

        if (user != null)
        {
            List<Contact> sortedContacts = user.contacts.OrderBy(contact => contact.name).ToList();
            foreach (var contact in sortedContacts)
            {
                var con = Instantiate(_contactPreFab,_contactListParent).GetComponent<Contacts>();
                con.SetData(contact);
                contacts.Add(con);
            }
            NameTextFild.text = user.name;
            base.ActivateScreen();
        }else
        {
            UiManager.instance.SwitchScreen(GameScreens.Login);
        }
    }
    void OnAddContact()
    {
        UiManager.instance.SwitchScreen(GameScreens.AddContact);
    }
    void OnLogout(){
        UserData.user = null;
        UiManager.instance.SwitchScreen(GameScreens.Login);
    }
}
