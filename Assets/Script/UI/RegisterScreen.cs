using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class RegisterScreen : BaseScreen
{
    [SerializeField] TMP_InputField emailInputFild;
    [SerializeField] TMP_InputField PasswordInputFild;
    [SerializeField] TMP_InputField NumberInputFild;
    [SerializeField] TMP_InputField NameInputFild;
    [SerializeField] Text ErrorTextFild;

    [SerializeField] Button SingupButton;
    DataManager dataManager = new DataManager();

    
    private void Start()
    {
        SingupButton.onClick.AddListener(OnSingup);
    }
    public override void ActivateScreen()
    {
        if (UserData.user != null  && dataManager.ChackForUser(UserData.email,UserData.user.password) != null)
        {
            UiManager.instance.SwitchScreen(GameScreens.Home);
        }else
        {
            NameInputFild.text = "";
            NumberInputFild.text = "";
            PasswordInputFild.text = "";
            emailInputFild.text = "";
            base.ActivateScreen();
        }
    }
void OnSingup()
{
    if (string.IsNullOrEmpty(NameInputFild.text) ||
        string.IsNullOrEmpty(NumberInputFild.text) ||
        string.IsNullOrEmpty(PasswordInputFild.text) ||
        string.IsNullOrEmpty(emailInputFild.text))
    {
        ErrorTextFild.text = "Please fill in all fields.";
        return; 
    }
    
    
    User user = new User(
        NameInputFild.text,
        NumberInputFild.text,
        PasswordInputFild.text,
        emailInputFild.text
    );

    
    string message = dataManager.AddUser(user);

    
    if (!string.IsNullOrEmpty(message))
    {
        
        ErrorTextFild.text = message;
        return; 
    }

    
    ErrorTextFild.text = "";

    
    UiManager.instance.SwitchScreen(GameScreens.Login);
}

}
