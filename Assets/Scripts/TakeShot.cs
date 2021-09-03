using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class TakeShot : MonoBehaviour
{
    [SerializeField]
    private GameObject _success;
    [SerializeField]
    private GameObject _wait;
    [SerializeField]
    private GameObject _failed;
    [SerializeField]
    private GameObject _score;
    public RawImage _camImage;
    public RawImage _shotImage;
    private WebCamTexture _webCam;
    public RawImage _animalImg;

    private string _fileName = "photo";
    //counter to get the last picture taken
    private int _captureCounter = 0;
    public Quaternion _baseRotation;
    
    private byte[] _bytes;
    private Texture2D _snap;

    private UIManager _uiManager;
    public Token loadedToken;
    public List<ChallengeItems> challengeList;

    // Start is called before the first frame update
    void Start()
    {
        //access the webcam
        _webCam = new WebCamTexture();
        _camImage.texture = _webCam;
        _webCam.Play();
        _baseRotation = transform.rotation;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        DeserializeJSON(LoginScript._details);
        challengeList = JsonConvert.DeserializeObject<List<ChallengeItems>>(Challenge.challengeDetails);
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
    //change camera's orientation if the device's angle's changed
    void Update()
    {
        transform.rotation = _baseRotation * Quaternion.AngleAxis(_webCam.videoRotationAngle, Vector3.up);
    }

    public void ButtonSnap()
    {
        StartCoroutine(SaveImage());
    }


    public class ChallengeItems
    {
        public string id;
        public string name;
        public string image;
    }

    private IEnumerator SaveImage()
    {
        yield return new WaitForEndOfFrame();
        //creates camera texture
        _snap = new Texture2D(_webCam.width, _webCam.height);

        //where the bytes are gonna be stored
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, _fileName);
        Debug.Log(Application.persistentDataPath);

        _snap.SetPixels(_webCam.GetPixels());
        _snap.Apply();
        _bytes = _snap.EncodeToPNG();
        _shotImage.texture = _snap as Texture;

        System.IO.File.WriteAllBytes(filePath + _fileName + _captureCounter.ToString() + ".png", _snap.EncodeToPNG());

        ++_captureCounter;
        _wait.SetActive(true);
        StartCoroutine(Upload());
    }


    private IEnumerator Upload()
    {
        string animal = GameManager._chosenItem;
        foreach (ChallengeItems var in challengeList)
        {
            if (animal.Contains("badger"))
            {
                UnityWebRequest _upload = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/ca1c0f212818e91f285cc5498f4d7c6c", _bytes);
                Debug.Log(var.name);
                _upload.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload.SendWebRequest();
                if (_upload.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload.error);
                    break;
                }
            } else if (animal.Contains("bat"))
            {
                UnityWebRequest _upload2 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload2.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload2.SendWebRequest();
                if (_upload2.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload2.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload2.error);
                    break;
                }
            }
            else if (animal.Contains("carterpillar"))
            {
                UnityWebRequest _upload3 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload3.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload3.SendWebRequest();
                if (_upload3.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload3.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload3.error);
                    break;
                }
            }
            else if (animal.Contains("cat"))
            {
                UnityWebRequest _upload4 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload4.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload4.SendWebRequest();
                if (_upload4.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload4.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload4.error);
                    break;
                }
            }
            else if (animal.Contains("crow"))
            {
                UnityWebRequest _upload5 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload5.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload5.SendWebRequest();
                if (_upload5.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload5.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload5.error);
                    break;
                }
            }
            else if (animal.Contains("cow"))
            {
                UnityWebRequest _upload6 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload6.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload6.SendWebRequest();
                if (_upload6.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload6.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload6.error);
                    break;
                }
            }
            else if (animal.Contains("fox"))
            {
                UnityWebRequest _upload7 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload7.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload7.SendWebRequest();
                if (_upload7.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload7.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload7.error);
                    break;
                }
            }
            else if (animal.Contains("frog"))
            {
                UnityWebRequest _upload8 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload8.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload8.SendWebRequest();
                if (_upload8.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload8.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload8.error);
                    break;
                }
            }
            else if (animal.Contains("horse"))
            {
                UnityWebRequest _upload9 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload9.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload9.SendWebRequest();
                if (_upload9.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload9.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload9.error);
                    break;
                }
            }
            else if (animal.Contains("magpie"))
            {
                UnityWebRequest _upload10 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload10.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload10.SendWebRequest();
                if (_upload10.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload10.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload10.error);
                    break;
                }
            }
            else if (animal.Contains("panda"))
            {
                UnityWebRequest _upload11 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload11.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload11.SendWebRequest();
                if (_upload11.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload11.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload11.error);
                    break;
                }
            }
            else if (animal.Contains("parrot"))
            {
                UnityWebRequest _upload12 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload12.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload12.SendWebRequest();
                if (_upload12.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload12.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload12.error);
                    break;
                }
            }
            else if (animal.Contains("penguin"))
            {
                UnityWebRequest _upload13 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload13.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload13.SendWebRequest();
                if (_upload13.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload13.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload13.error);
                    break;
                }
            }
            else if (animal.Contains("puffin"))
            {
                UnityWebRequest _upload14 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload14.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload14.SendWebRequest();
                if (_upload14.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload14.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload14.error);
                    break;
                }
            }
            else if (animal.Contains("rabbit"))
            {
                UnityWebRequest _upload15 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload15.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload15.SendWebRequest();
                if (_upload15.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload15.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload15.error);
                    break;
                }
            }
            else if (animal.Contains("rat"))
            {
                UnityWebRequest _upload16 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload16.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload16.SendWebRequest();
                if (_upload16.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload16.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload16.error);
                    break;
                }
            }
            else if (animal.Contains("slug"))
            {
                UnityWebRequest _upload17 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload17.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload17.SendWebRequest();
                if (_upload17.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload17.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload17.error);
                    break;
                }
            }
            else if (animal.Contains("snail"))
            {
                UnityWebRequest _upload18 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload18.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload18.SendWebRequest();
                if (_upload18.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload18.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload18.error);
                    break;
                }
            }
            else if (animal.Contains("snake"))
            {
                UnityWebRequest _upload19 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload19.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload19.SendWebRequest();
                if (_upload19.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload19.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload19.error);
                    break;
                }
            }
            else if (animal.Contains("sparrow"))
            {
                UnityWebRequest _upload20 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload20.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload20.SendWebRequest();
                if (_upload20.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload20.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload20.error);
                    break;
                }
            }
            else if (animal.Contains("squirrel"))
            {
                UnityWebRequest _upload21 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload21.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload21.SendWebRequest();
                if (_upload21.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload21.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload21.error);
                    break;
                }
            }
            else if (animal.Contains("swan"))
            {
                UnityWebRequest _upload22 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload22.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload22.SendWebRequest();
                if (_upload22.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload22.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload22.error);
                    break;
                }
            }
            else if (animal.Contains("tiger"))
            {
                UnityWebRequest _upload23 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload23.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload23.SendWebRequest();
                if (_upload23.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload23.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload23.error);
                    break;
                }
            }
            else if (animal.Contains("wolf"))
            {
                UnityWebRequest _upload24 = UnityWebRequest.Put("https://eyespy-317115.ew.r.appspot.com/challenge/england_animals/recog/" + var.id, _bytes);
                Debug.Log(var.name);
                _upload24.SetRequestHeader("TOKEN", loadedToken.token);
                yield return _upload24.SendWebRequest();
                if (_upload24.result == UnityWebRequest.Result.Success)
                {
                    string result = _upload24.downloadHandler.text;
                    if (result.Contains("false") != true)
                    {
                        _uiManager.UpdateScore(100);
                        _wait.SetActive(false);
                        _success.SetActive(true);
                        _score.SetActive(true);
                        SoundManager.Playsound();
                        yield return new WaitForSeconds(3);
                        break;
                    }
                    else
                    {

                        _wait.SetActive(false);
                        _failed.SetActive(true);
                        SoundManager.Playsound2();
                    }
                    break;
                }
                else
                {

                    Debug.Log(_upload24.error);
                    break;
                }
            }
        }
    }
}


