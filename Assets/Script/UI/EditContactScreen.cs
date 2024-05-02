
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class EditContactScreen : BaseScreen
{
    [SerializeField] TMP_InputField nameInputFild;
    [SerializeField] TMP_InputField numberInputFild;
    [SerializeField] TMP_InputField emailInputFild;
    [SerializeField] TMP_InputField addressInputFild;
    [SerializeField] Button EditContactButton;
    [SerializeField] Button RemoveContactButton;
    [SerializeField] Button BackButton;

    DataManager dataManager = new DataManager();
   
    private void Start() {
        EditContactButton.onClick.AddListener(EditContact);
        RemoveContactButton.onClick.AddListener(RemoveContact);
        BackButton.onClick.AddListener(OnBack);
    }
    void OnBack(){
        UiManager.instance.SwitchScreen(GameScreens.Home);
    }
    public override void ActivateScreen()
    {
        Contact contact= UserData.contact;
            nameInputFild.text = contact.name; 
            numberInputFild.text = contact.number;
            addressInputFild.text =contact.address;
            emailInputFild.text =contact.email;
        base.ActivateScreen();
    }
    void EditContact(){
        Contact newcontact = new Contact(
            nameInputFild.text,
            numberInputFild.text,
            addressInputFild.text,
            emailInputFild.text
        );
        dataManager.EditContact(UserData.email,UserData.contact,newcontact);

        UiManager.instance.SwitchScreen(GameScreens.Home);
    }
    void RemoveContact(){
        dataManager.RemoveContact(UserData.email,UserData.contact);
        UiManager.instance.SwitchScreen(GameScreens.Home);

    }
}