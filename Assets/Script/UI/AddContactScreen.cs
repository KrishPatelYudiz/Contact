
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class AddContactScreen : BaseScreen
{
    [SerializeField] TMP_InputField nameInputFild;
    [SerializeField] TMP_InputField numberInputFild;
    [SerializeField] TMP_InputField emailInputFild;
    [SerializeField] TMP_InputField addressInputFild;
    [SerializeField] Button addContactButton;
    DataManager dataManager = new DataManager();

    private void Start() {
        addContactButton.onClick.AddListener(AddContact);
    }
    public override void ActivateScreen()
    {
            nameInputFild.text = ""; 
            numberInputFild.text = "";
            addressInputFild.text ="";
            emailInputFild.text ="";
        base.ActivateScreen();
    }
    void AddContact(){
        Contact contact = new Contact(
            nameInputFild.text,
            numberInputFild.text,
            addressInputFild.text,
            emailInputFild.text
        );
        dataManager.AddContact(UserData.email,contact);

        UiManager.instance.SwitchScreen(GameScreens.Home);
    }
}