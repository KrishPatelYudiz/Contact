using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class HomeScreen : BaseScreen
{
    [SerializeField] Button _addContactButton;
    [SerializeField] GameObject _contactPreFab;
    [SerializeField] Transform _contactListParent;

    List<Contacts> contacts= new List<Contacts>();
    DataManager dataManager = new DataManager();

    
    private void Start()
    {
        _addContactButton.onClick.AddListener(OnAddContact);
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
            foreach (var contact in user.contacts)
            {
                var con = Instantiate(_contactPreFab,_contactListParent).GetComponent<Contacts>();
                con.SetData(contact);
                contacts.Add(con);
            }
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
}
