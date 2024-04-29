using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager 
{

    public string FileName = "data.abc";
    public void UpdateData(List<User> data)
    {
        string binaryPath = Application.persistentDataPath + FileName;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream binaryStream = new FileStream(binaryPath, FileMode.Create);
        binaryFormatter.Serialize(binaryStream, data);
        binaryStream.Close();

    }

    public User ChackForUser(string email,string password){
            
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string binaryPath = Application.persistentDataPath + FileName;
 
        FileStream binaryStream = new FileStream(binaryPath, FileMode.Open);
        List<User> data = (List<User>) binaryFormatter.Deserialize(binaryStream);
 
        binaryStream.Close();

        User user = data.Find(user => user.email == email);
        if (user != null && user.password == password)
        {
            return user;
            
        }
        Debug.Log(data[0].name);
        
        return null;
    }
    public void AddContact(string email,Contact contact){
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string binaryPath = Application.persistentDataPath + FileName;
 
        FileStream binaryStream = new FileStream(binaryPath, FileMode.Open);
        List<User> data = (List<User>) binaryFormatter.Deserialize(binaryStream);
 
        binaryStream.Close();

        data.Find(user => user.email == email).contacts.Add(contact);
        UpdateData(data);
        
    }
    public void AddUser(User user){
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string binaryPath = Application.persistentDataPath + FileName;
 
        FileStream binaryStream = new FileStream(binaryPath, FileMode.Open);
        List<User> data = (List<User>) binaryFormatter.Deserialize(binaryStream);
 
        binaryStream.Close();

        data.Add(user);


        UpdateData(data);
        
    }

    public void RemoveContact( string email, Contact contact){
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string binaryPath = Application.persistentDataPath + FileName;
 
        FileStream binaryStream = new FileStream(binaryPath, FileMode.Open);
        List<User> data = (List<User>) binaryFormatter.Deserialize(binaryStream);
 
        binaryStream.Close();

        User user =  data.Find(user => user.email == email );
        Contact cont = user.contacts.Find(conta => conta.IsEqual(contact));
        user.contacts.Remove(cont);
        UpdateData(data);

    }
    public void EditContact(string email,Contact contact,Contact newcontact){
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string binaryPath = Application.persistentDataPath + FileName;
 
        FileStream binaryStream = new FileStream(binaryPath, FileMode.Open);
        List<User> data = (List<User>) binaryFormatter.Deserialize(binaryStream);
 
        binaryStream.Close();

        User user =  data.Find(user => user.email == email );
        Contact cont = user.contacts.Find(conta => conta.IsEqual(contact));
        user.contacts.Remove(cont);
        user.contacts.Add(newcontact);
        UpdateData(data);
    }
}
