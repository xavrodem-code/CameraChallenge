using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text _scoreText;
    public static int _score;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateScore(int points)
    {
        _score += points;
        _scoreText.text = "Score: " + points;
        Debug.Log(points);
        SaveScore();
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("SavedScore", _score);
        PlayerPrefs.Save();
        _score = PlayerPrefs.GetInt("SavedScore", _score);
    }
}
