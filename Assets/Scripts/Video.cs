using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    private string _fileName = "video";
    public void Init()
    {
        StartCoroutine(Download());
    }

    IEnumerator Download()
    {
        UnityWebRequest _getVideo = UnityWebRequest.Get("https://storage.googleapis.com/spygamevideos/e0eb67738d6afa141f67ff5191065ad6.mkv");
        _getVideo.SetRequestHeader("TOKEN", LoginScript.ID);
        yield return _getVideo.SendWebRequest();
        if (_getVideo.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("GetVideoError");
        }
        else
        {
            string filePath = string.Format("{0}/{1}.pdb", Application.persistentDataPath, _fileName);
            System.IO.File.WriteAllText(filePath, _getVideo.downloadHandler.text);
            Debug.Log("VideoSaved");
            Debug.Log(filePath);
        }
    }
}
