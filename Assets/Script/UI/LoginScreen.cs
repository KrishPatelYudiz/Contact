using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class LoginScreen : BaseScreen
{
    [SerializeField] TMP_InputField emailInputFild;
    [SerializeField] TMP_InputField PasswordInputFild;
    [SerializeField] Button LoginButton;
    [SerializeField] Button SingupButton;
    DataManager dataManager = new DataManager();

    
    private void Start()
    {
        LoginButton.onClick.AddListener(OnLogin);
        SingupButton.onClick.AddListener(OnSingup);
    }
    public override void ActivateScreen()
    {
        if (UserData.user != null  && dataManager.ChackForUser(UserData.email,UserData.user.password) != null)
        {
            UiManager.instance.SwitchScreen(GameScreens.Home);
        }else
        {
            
            base.ActivateScreen();
        }
    }
    void OnLogin()
    {
        User user = dataManager.ChackForUser(emailInputFild.text,PasswordInputFild.text);
        if (user != null)
        {
            UserData.user = user;
            UiManager.instance.SwitchScreen(GameScreens.Home);
        } 
        emailInputFild.text="";
        PasswordInputFild.text="";
    }
    void OnSingup()
    {
       UiManager.instance.SwitchScreen(GameScreens.Register);
    }
}
