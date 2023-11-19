using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreDisplay.text= $"Score: {score}";
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void HighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
