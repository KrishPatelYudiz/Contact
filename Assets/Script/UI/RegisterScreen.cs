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
            
            base.ActivateScreen();
        }
    }
    void OnSingup()
    {
      User user= new User(
            NameInputFild.text,
            NumberInputFild.text,
            PasswordInputFild.text,
            emailInputFild.text
      );
      Debug.Log(user.name);
      dataManager.AddUser(user);
      
      UiManager.instance.SwitchScreen(GameScreens.Login);
    }
}
