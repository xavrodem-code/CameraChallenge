using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownload : MonoBehaviour
{
    public List<ChallengeItems> challengeList;
    // Start is called before the first frame update
    void Start()
    {
        challengeList = JsonConvert.DeserializeObject<List<ChallengeItems>>(Challenge.challengeDetails);
        StartCoroutine(SelectAnimal());
    }

    private IEnumerator SelectAnimal()
    {
        foreach (ChallengeItems var in challengeList)
        {
            string animal = GameManager._chosenItem;

            if (animal.Contains("badger"))
            {
                UnityWebRequest badgerImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-badger.jpg");
                yield return badgerImg.SendWebRequest();
                if (badgerImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(badgerImg.error);
                    break;
                }
                else
                {
                    Texture2D badgerTexture = ((DownloadHandlerTexture)badgerImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = badgerTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            
            else if (animal.Contains("bat"))
            {
                UnityWebRequest batImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-pipistrelle-bat.jpg");
                yield return batImg.SendWebRequest();
                if (batImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(batImg.error);
                    break;
                }
                else
                {
                    Texture2D batTexture = ((DownloadHandlerTexture)batImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = batTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("carterpillar"))
            {
                UnityWebRequest carterpillarImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-caterpillar.jpg");
                yield return carterpillarImg.SendWebRequest();
                if (carterpillarImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(carterpillarImg.error);
                    break;
                }
                else
                {
                    Texture2D carterpillarTexture = ((DownloadHandlerTexture)carterpillarImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = carterpillarTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("cat"))
            {
                UnityWebRequest catImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-cat.jpg");
                yield return catImg.SendWebRequest();
                if (catImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(catImg.error);
                    break;
                }
                else
                {
                    Texture2D catTexture = ((DownloadHandlerTexture)catImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = catTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("cow"))
            {
                UnityWebRequest cowImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-cow.jpg");
                yield return cowImg.SendWebRequest();
                if (cowImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(cowImg.error);
                    break;
                }
                else
                {
                    Texture2D cowTexture = ((DownloadHandlerTexture)cowImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = cowTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("crow"))
            {
                UnityWebRequest crowImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-crow.jpg");
                yield return crowImg.SendWebRequest();
                if (crowImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(crowImg.error);
                    break;
                }
                else
                {
                    Texture2D crowTexture = ((DownloadHandlerTexture)crowImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = crowTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("fox"))
            {
                UnityWebRequest foxImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-fox.jpg");
                yield return foxImg.SendWebRequest();
                if (foxImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(foxImg.error);
                    break;
                }
                else
                {
                    Texture2D foxTexture = ((DownloadHandlerTexture)foxImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = foxTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("frog"))
            {
                UnityWebRequest frogImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-frog.jpg");
                yield return frogImg.SendWebRequest();
                if (frogImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(frogImg.error);
                    break;
                }
                else
                {
                    Texture2D frogTexture = ((DownloadHandlerTexture)frogImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = frogTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("horse"))
            {
                UnityWebRequest horseImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-horse.jpeg");
                yield return horseImg.SendWebRequest();
                if (horseImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(horseImg.error);
                    break;
                }
                else
                {
                    Texture2D horseTexture = ((DownloadHandlerTexture)horseImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = horseTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("magpie"))
            {
                UnityWebRequest magpieImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-magpie.jpg");
                yield return magpieImg.SendWebRequest();
                if (magpieImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(magpieImg.error);
                    break;
                }
                else
                {
                    Texture2D magpieTexture = ((DownloadHandlerTexture)magpieImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = magpieTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("panda"))
            {
                UnityWebRequest pandaImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-panda.jpg");
                yield return pandaImg.SendWebRequest();
                if (pandaImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(pandaImg.error);
                    break;
                }
                else
                {
                    Texture2D pandaTexture = ((DownloadHandlerTexture)pandaImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = pandaTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("parrot"))
            {
                UnityWebRequest parrotImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-parrot.jpg");
                yield return parrotImg.SendWebRequest();
                if (parrotImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(parrotImg.error);
                    break;
                }
                else
                {
                    Texture2D parrotTexture = ((DownloadHandlerTexture)parrotImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = parrotTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("penguin"))
            {
                UnityWebRequest penguinImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-penguin.jpg");
                yield return penguinImg.SendWebRequest();
                if (penguinImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(penguinImg.error);
                    break;
                }
                else
                {
                    Texture2D penguinTexture = ((DownloadHandlerTexture)penguinImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = penguinTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("puffin"))
            {
                UnityWebRequest puffinImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-puffin.jpg");
                yield return puffinImg.SendWebRequest();
                if (puffinImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(puffinImg.error);
                    break;
                }
                else
                {
                    Texture2D puffinTexture = ((DownloadHandlerTexture)puffinImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = puffinTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("rabbit"))
            {
                UnityWebRequest rabbitImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-rabbit.jpg");
                yield return rabbitImg.SendWebRequest();
                if (rabbitImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(rabbitImg.error);
                    break;
                }
                else
                {
                    Texture2D rabbitTexture = ((DownloadHandlerTexture)rabbitImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = rabbitTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("rat"))
            {
                UnityWebRequest ratImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-rat.jpg");
                yield return ratImg.SendWebRequest();
                if (ratImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(ratImg.error);
                    break;
                }
                else
                {
                    Texture2D ratTexture = ((DownloadHandlerTexture)ratImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = ratTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("slug"))
            {
                UnityWebRequest slugImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-slug.jpg");
                yield return slugImg.SendWebRequest();
                if (slugImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(slugImg.error);
                    break;
                }
                else
                {
                    Texture2D slugTexture = ((DownloadHandlerTexture)slugImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = slugTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("snake"))
            {
                UnityWebRequest snakeImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-snake.jpg");
                yield return snakeImg.SendWebRequest();
                if (snakeImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(snakeImg.error);
                    break;
                }
                else
                {
                    Texture2D snakeTexture = ((DownloadHandlerTexture)snakeImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = snakeTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("snail"))
            {
                UnityWebRequest snailImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-snail.jpg");
                yield return snailImg.SendWebRequest();
                if (snailImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(snailImg.error);
                    break;
                }
                else
                {
                    Texture2D snailTexture = ((DownloadHandlerTexture)snailImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = snailTexture;
                    Debug.Log("Done");
                    break;
                }
            }

            else if (animal.Contains("sparrow"))
            {
                UnityWebRequest sparrowImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-sparrow.jpg");
                yield return sparrowImg.SendWebRequest();
                if (sparrowImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(sparrowImg.error);
                    break;
                }
                else
                {
                    Texture2D sparrowTexture = ((DownloadHandlerTexture)sparrowImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = sparrowTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("squirrel"))
            {
                UnityWebRequest squirrelImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-squirrel.jpeg");
                yield return squirrelImg.SendWebRequest();
                if (squirrelImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(squirrelImg.error);
                    break;
                }
                else
                {
                    Texture2D squirrelTexture = ((DownloadHandlerTexture)squirrelImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = squirrelTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("swan"))
            {
                UnityWebRequest swanImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-swan.jpg");
                yield return swanImg.SendWebRequest();
                if (swanImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(swanImg.error);
                    break;
                }
                else
                {
                    Texture2D swanTexture = ((DownloadHandlerTexture)swanImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = swanTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("tiger"))
            {
                UnityWebRequest tigerImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-tiger.png");
                yield return tigerImg.SendWebRequest();
                if (tigerImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(tigerImg.error);
                    break;
                }
                else
                {
                    Texture2D tigerTexture = ((DownloadHandlerTexture)tigerImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = tigerTexture;
                    Debug.Log("Done");
                    break;
                }
            }
            else if (animal.Contains("wolf"))
            {
                UnityWebRequest wolfImg = UnityWebRequestTexture.GetTexture("https://storage.googleapis.com/spygameimages/animal-wolf.jpg");
                yield return wolfImg.SendWebRequest();
                if (wolfImg.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(wolfImg.error);
                    break;
                }
                else
                {
                    Texture2D wolfTexture = ((DownloadHandlerTexture)wolfImg.downloadHandler).texture as Texture2D;
                    Debug.Log("Image downloaded");
                    this.gameObject.GetComponent<RawImage>().texture = wolfTexture;
                    Debug.Log("Done");
                    break;
                }
            }
        }
    }

    Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    public class ChallengeItems
    {
        public string name;
        public string image;
    }
}
