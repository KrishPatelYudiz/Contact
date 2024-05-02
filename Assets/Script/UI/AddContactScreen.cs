
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class AddContactScreen : BaseScreen
{
    [SerializeField] TMP_InputField nameInputFild;
    [SerializeField] TMP_InputField numberInputFild;
    [SerializeField] TMP_InputField emailInputFild;
    [SerializeField] TMP_InputField addressInputFild;
    
    [SerializeField] Text ErrorTextFild;

    [SerializeField] Button addContactButton;
    [SerializeField] Button BackButton;

    DataManager dataManager = new DataManager();

    private void Start() {
        addContactButton.onClick.AddListener(AddContact);
        BackButton.onClick.AddListener(OnBack);
    }
    void OnBack(){
        UiManager.instance.SwitchScreen(GameScreens.Home);
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


        if (string.IsNullOrEmpty(nameInputFild.text) ||
        string.IsNullOrEmpty(numberInputFild.text) ||
        string.IsNullOrEmpty(addressInputFild.text) ||
        string.IsNullOrEmpty(emailInputFild.text))
        {
            ErrorTextFild.text = "Please fill in all fields.";
            return; 
        }
        ErrorTextFild.text = ""; 
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