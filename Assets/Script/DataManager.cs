using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.InteropServices;

public class DataManager 
{

    public string FileName = "/data.abc";
    public void UpdateData(List<User> data)
    {
        string binaryPath = Application.persistentDataPath + FileName;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream binaryStream = new FileStream(binaryPath, FileMode.Create);
        binaryFormatter.Serialize(binaryStream, data);
        binaryStream.Close();
        
        Debug.Log(binaryPath);
        if (data != null && UserData.user != null)
        {
            UserData.user = data.Find(x => x.email == UserData.email);
        }

    }
    public List<User> GetUsers(){
        List<User> data = new List<User>();
        try
        {
            
            string binaryPath = Application.persistentDataPath + FileName;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            
            FileStream binaryStream = new FileStream(binaryPath, FileMode.Open);
            data = (List<User>) binaryFormatter.Deserialize(binaryStream);
 
            binaryStream.Close();
        }
        catch (System.Exception)
        {
            
            Debug.Log("Fill Not Found");
        }
        return data;
    }
    public User ChackForUser(string email,string password){
            
        List<User> data = GetUsers();

        User user = data.Find(user => user.email == email);
        if (user != null && user.password == password)
        {
            
            return user;
        }
        Debug.Log(data[0].name);
        
        return null;
    }
    public void AddContact(string email,Contact contact){
        List<User> data = GetUsers();

        data.Find(user => user.email == email).contacts.Add(contact);
        UpdateData(data);
        
    }
    public string AddUser(User user){
        List<User> data = GetUsers();
        if (data != null)
        {
            User tempUser = data.Find(x => user.email == x.email);
            if (tempUser != null)
            {
                return "Email is already used For Login";
            }
        }
        data.Add(user);


        UpdateData(data);
        return "";
        
    }

    public void RemoveContact( string email, Contact contact){
        List<User> data = GetUsers();

        User user =  data.Find(user => user.email == email );
        Contact cont = user.contacts.Find(conta => conta.IsEqual(contact));
        user.contacts.Remove(cont);
        UpdateData(data);

    }
    public void EditContact(string email,Contact contact,Contact newcontact){
        List<User> data = GetUsers();
 
        User user =  data.Find(user => user.email == email );
        Contact cont = user.contacts.Find(conta => conta.IsEqual(contact));
        user.contacts.Remove(cont);
        user.contacts.Add(newcontact);
        UpdateData(data);
    }

}
