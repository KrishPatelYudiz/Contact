using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contacts : MonoBehaviour
{
     [SerializeField] Text Name;
     [SerializeField] Text Number;
     [SerializeField] Button editButton;
    Contact contact = new Contact();
    public void SetData(Contact contact){
        this.contact = contact;
        Name.text = contact.name;
        Number.text = contact.number;
    }

    [SerializeField] Button _CallButton;

    private void Start() {
        _CallButton.onClick.AddListener(OnCall);
        editButton.onClick.AddListener(OnEdit);
    }
    void OnEdit(){
        UserData.contact = contact;
        UiManager.instance.SwitchScreen(GameScreens.EditContact);
    }
    void OnCall() {
        //? calling Pad
    }
}
