using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
public class LoginScript : MonoBehaviour
{
    public static string ID;
    public static string _details;
    void Start()
    {
        ID = SystemInfo.deviceUniqueIdentifier;

        Debug.Log("Device ID: " + SystemInfo.deviceUniqueIdentifier);
        GetDetails();
    }

    void GetDetails()
    {
        StartCoroutine(Download());
    }

    IEnumerator Download()
    {
        UnityWebRequest details = UnityWebRequest.Get("https://eyespy-317115.ew.r.appspot.com/login/" + ID);
        Debug.Log("Token Request");
        yield return details.SendWebRequest();
        if (details.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(details.error);
        } else
        {
            Debug.Log(details.downloadHandler.text);
            string savePath = string.Format("{0}/{1}.pdb", Application.persistentDataPath, "Token");
            System.IO.File.WriteAllText(savePath, details.downloadHandler.text);
            Debug.Log("Token Saved");
            Debug.Log(ID);
            string json = details.downloadHandler.text;
            Debug.Log(json);
            _details = json;

            Token loadedToken = JsonUtility.FromJson<Token>(json);
            Debug.Log("Tested token: " + loadedToken.token);
            Debug.Log("Tested token: " + loadedToken.game);
            Debug.Log("Tested token: " + loadedToken.icon);
            Debug.Log("Tested token: " + loadedToken.started);
            Debug.Log("Tested token: " + loadedToken.timestamp);
            Debug.Log(_details);
        }
    }

    public class Token
    {
        public string token;
        public string game;
        public string icon;
        public string started;
        public string timestamp;
    }

}
