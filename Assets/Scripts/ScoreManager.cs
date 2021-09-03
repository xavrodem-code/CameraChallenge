using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private int _score;
    private int _points;
    private int _highScore = 0;

    public void IncreaseScore(int points)
    {
        _score += points;
        UpdateHighscore(_score);
        UpdateScore(_score);
    }

    private void UpdateHighscore(int score)
    {
        if (score > _highScore)
        {
            _highScore = score;
            PlayerPrefs.SetInt("Highscore", _highScore);
            PlayerPrefs.Save();
            Debug.Log("Score successfully saved");
        }
    }

    private void UpdateScore(int endScore)
    {
        _points = endScore;
        PlayerPrefs.SetInt("Points", _points);
        PlayerPrefs.Save();
        Debug.Log("Points successfully saved");

    }
}
