using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class UserData{
    public static User user;
    public static string email => user.email;
    public static Contact contact;
}

[Serializable]
public class User {
    public string name;
    public string email;
    public string password;
    public string number;

    public List<Contact> contacts = new List<Contact>();


    public User(){

    }
    public User(string name, string number, string password,string email){
        this.name = name;
        this.number = number;
        this.password = password;
        this.email = email;
    }
}

[Serializable]
public class Contact 
{
    public string name;
    public string number;
    public string address;
    public string email;


    public Contact(){

    }
    public Contact(string name, string number, string address,string email){
        this.name = name;
        this.number = number;
        this.address = address;
        this.email = email;
    }

    public bool IsEqual(Contact contact){

        if (contact.name == this.name && contact.number == this.number && contact.address == this.address && contact.email == this.email){
            return true;
        }
        return false;
    }
}
