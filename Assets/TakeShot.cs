using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class TakeShot : MonoBehaviour
{

    public RawImage _camImage;
    public RawImage _shotImage;
    private WebCamTexture _webCam;

    private string _fileName = "photo";
    //counter to get the last picture taken
    private int _captureCounter = 0;
    public Quaternion _baseRotation;
    
    private byte[] _bytes;
    private Texture2D _snap;

    private 

    // Start is called before the first frame update
    void Start()
    {
        //access the webcam
        _webCam = new WebCamTexture();
        _camImage.texture = _webCam;
        _webCam.Play();
        _baseRotation = transform.rotation;
    }

    //change camera's orientation if the device's angle's changed
    void Update()
    {
        transform.rotation = _baseRotation * Quaternion.AngleAxis(_webCam.videoRotationAngle, Vector3.up);
    }

    public void ButtonSnap()
    {
        StartCoroutine("SaveImage");
    }

    public void CheckPic()
    {
        StartCoroutine(SendFile("http://localhost:8080/recog/"));
    }

    private IEnumerator SaveImage()
    {
        yield return new WaitForEndOfFrame();
        //creates camera texture
        _snap = new Texture2D(_webCam.width, _webCam.height);

        //where the bytes are gonna be stored
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, _fileName);
        _bytes = _snap.EncodeToPNG();

        _snap.SetPixels(_webCam.GetPixels());
        _snap.Apply();
        _shotImage.texture = _snap as Texture;
        System.IO.File.WriteAllBytes(filePath + _fileName + _captureCounter.ToString() + ".png", _snap.EncodeToPNG());
        ++_captureCounter;
    }

    private IEnumerator SendFile(string _uploadURL)
    {
        Debug.Log("Not running");
        _captureCounter--;

        string _fullFileName = "photo" + _captureCounter + ".png";
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, _fileName);
        //access the file
        UnityWebRequest _localFile = new UnityWebRequest("file://" + filePath + _fullFileName)
        yield return _localFile;
        if (_localFile != null)
        {
            Debug.Log("File not found");
        }

        //Form to post data
        WWWForm _postForm = new WWWForm();
        //Send post
        _postForm.AddBinaryData("file", _localFile.downloadHandler.data, _fullFileName, "image/png");
        UnityWebRequest upload = UnityWebRequest.Post(_uploadURL, _postForm);
        yield return upload;
        if(upload.error != null)
        {
            Debug.Log("Error");
        }

        _captureCounter++;
    }
}
