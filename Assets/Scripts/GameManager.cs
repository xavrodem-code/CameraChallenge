using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
 
{
    public static string _chosenItem; 
    public void Back()
    {
        SceneManager.LoadScene("ScrollItemMenu");
    }
    public void Camera()
    {
        SceneManager.LoadScene(6);
    }
    public void England()
    {
        SceneManager.LoadScene("ScrollItemMenu");
    }


    public void Badger()
    {
        _chosenItem = "badger";
        SceneManager.LoadScene("Shot");
    }

    public void Bat()
    {
        _chosenItem = "bat";
        SceneManager.LoadScene("Shot");
    }

    public void Carterpillar()
    {
        _chosenItem = "carterpillar";
        SceneManager.LoadScene("Shot");
    }

    public void Cat()
    {
        _chosenItem = "cat";
        SceneManager.LoadScene("Shot");
    }

    public void Cow()
    {
        _chosenItem = "cow";
        SceneManager.LoadScene("Shot");
    }

    public void Crow()
    {
        _chosenItem = "crow";
        SceneManager.LoadScene("Shot");
    }

    public void Fox()
    {
        _chosenItem = "fox";
        SceneManager.LoadScene("Shot");
    }

    public void Frog()
    {
        _chosenItem = "frog";
        SceneManager.LoadScene("Shot");
    }

    public void Horse()
    {
        _chosenItem = "horse";
        SceneManager.LoadScene("Shot");
    }

    public void Magpie()
    {
        _chosenItem = "magpie";
        SceneManager.LoadScene("Shot");
    }

    public void Panda()
    {
        _chosenItem = "panda";
        SceneManager.LoadScene("Shot");
    }

    public void Parrot()
    {
        _chosenItem = "parrot";
        SceneManager.LoadScene("Shot");
    }

    public void Penguin()
    {
        _chosenItem = "penguin";
        SceneManager.LoadScene("Shot");
    }

    public void Puffin()
    {
        _chosenItem = "puffin";
        SceneManager.LoadScene("Shot");
    }

    public void Rabbit()
    {
        _chosenItem = "rabbit";
        SceneManager.LoadScene("Shot");
    }

    public void Rat()
    {
        _chosenItem = "rat";
        SceneManager.LoadScene("Shot");
    }

    public void Slug()
    {
        _chosenItem = "slug";
        SceneManager.LoadScene("Shot");
    }

    public void Snake()
    {
        _chosenItem = "snake";
        SceneManager.LoadScene("Shot");
    }

    public void Snail()
    {
        _chosenItem = "snail";
        SceneManager.LoadScene("Shot");
    }

    public void Sparrow()
    {
        _chosenItem = "sparrow";
        SceneManager.LoadScene("Shot");
    }

    public void Squirrel()
    {
        _chosenItem = "squirrel";
        SceneManager.LoadScene("Shot");
    }

    public void Swan()
    {
        _chosenItem = "swan";
        SceneManager.LoadScene("Shot");
    }

    public void Tiger()
    {
        _chosenItem = "tiger";
        SceneManager.LoadScene("Shot");
    }

    public void Wolf()
    {
        _chosenItem = "wolf";
        SceneManager.LoadScene("Shot");
    }
}
 