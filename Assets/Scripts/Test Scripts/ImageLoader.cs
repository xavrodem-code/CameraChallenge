using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public void Download()
    {
        StartCoroutine(GetTexture());
    }

    private IEnumerator GetTexture()
    {
        UnityWebRequest _getImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-pipistrelle-bat.jpg");
        yield return _getImg.SendWebRequest();

        if (_getImg.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(_getImg.error);
        }
        else
        {
            //handle texture data by setting a 2DTexture object
            Texture2D webTexture = ((DownloadHandlerTexture)_getImg.downloadHandler).texture as Texture2D;
            //create sprite from the texture
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            this.gameObject.GetComponent<Image>().sprite = webSprite;
        }
    }

    Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}
