using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class Challenge : MonoBehaviour
{
    public Token loadedToken;
    public static string challengeDetails;
    public List<ChallengeItems> challengeList;
 
    // Start is called before the first frame update
    void Start()
    {
        DeserializeJSON(LoginScript._details);
        StartCoroutine(GetChallenge());
    }

    void DeserializeJSON(string json)
    {
        loadedToken = JsonUtility.FromJson<Token>(json);
        Debug.Log("Tested token: " + loadedToken.token);
    }

    public class Token
    {
        public string token;
        public string game;
        public string icon;
        public string started;
        public string timestamp;
    }

    private IEnumerator GetChallenge()
    {
        UnityWebRequest challenges = UnityWebRequest.Get("https://eyespy-317115.ew.r.appspot.com/challenge/england/items");
        challenges.SetRequestHeader("TOKEN", loadedToken.token);
        yield return challenges.SendWebRequest();
        if (challenges.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(challenges.error);
        }
        else
        {
            Debug.Log(challenges.downloadHandler.text);
            challengeDetails = challenges.downloadHandler.text;
            challengeList = JsonConvert.DeserializeObject<List<ChallengeItems>>(challenges.downloadHandler.text);
            foreach (ChallengeItems var in challengeList)
            {
                if (var.name == "panda")
                {
                    Debug.Log(var.image);
                }
            }
        }
    }

    public class ChallengeItems
    {
        public string id;
        public string name;
        public string image;
    }
}




