using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadChallenge : MonoBehaviour
{
    public void ChallengeDownload()
    {
        StartCoroutine(GetChallenge());
    }

    private IEnumerator GetChallenge()
    {
        UnityWebRequest challenges = UnityWebRequest.Get("https://eyespy-317115.ew.r.appspot.com/challenge/england/items");
        challenges.SetRequestHeader("TOKEN", LoginScript.ID);
        yield return challenges.SendWebRequest();
        if (challenges.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(challenges.error);
        } else
        {
            Debug.Log(challenges.downloadHandler.text);
        }
    }

    public void DownloadID()
    {
        StartCoroutine(GetID());
    }

    private IEnumerator GetID()
    {
        UnityWebRequest id = UnityWebRequest.Get("https://eyespy-317115.ew.r.appspot.com/challenge/england/items");
        id.SetRequestHeader("TOKEN", LoginScript.ID);
        yield return id.SendWebRequest();
        if (id.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(id.error);
        } else
        {
            Debug.Log(id.downloadHandler.text);
        }
    }
}
