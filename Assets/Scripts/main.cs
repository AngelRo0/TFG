using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;   // RestClient
using UnityEngine.UI;

public class main : MonoBehaviour
{
    private string database_url = "https://vr-alisoft-firebase-default-rtdb.europe-west1.firebasedatabase.app/";
    public string username;
    public string email;
    public string name;
    User user = new User();

    // Start is called before the first frame update
    void Start()
    {
        /*Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
        var dependencyStatus = task.Result;
        if (dependencyStatus == Firebase.DependencyStatus.Available) {
            // Create and hold a reference to your FirebaseApp,
            // where app is a Firebase.FirebaseApp property of your application class.
            var app = Firebase.FirebaseApp.DefaultInstance;

            // Set a flag here to indicate whether Firebase is ready to use by your app.
        } else {
            UnityEngine.Debug.LogError(System.String.Format(
            "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            // Firebase Unity SDK is not safe to use here.
        }
        });*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Savedata_toFirebase()
    {
        user.UserName = username;
        user.Email = email;
        RestClient.Put(database_url + "/" + username + ".json", user);
    }

    public void read_data()
    {
        RestClient.Get<User>(database_url + "/" + name + ".json").Then(response =>
        {
            user = response;
            Debug.Log(user.UserName);
            Debug.Log(user.Email);
        });
    }
}
