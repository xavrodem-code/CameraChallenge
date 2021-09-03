using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUI : MonoBehaviour
{
    public Text _pointsText;
    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        _pointsText.text = "Points: " + UIManager._score;
        Debug.Log("Points updated");
    }

    public void UpdateScore()
    {
        _score = PlayerPrefs.GetInt("SavedScore", _score);
        _pointsText.text = "Points: " + _score;
        Debug.Log("Score updated");
    }
}
