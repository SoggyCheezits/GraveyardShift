using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        highScoreDisplay = GetComponent<TextMeshProUGUI>();

        int highScore = PlayerPrefs.GetInt("HighScore");
        if (highScore == 0)
        {
            highScoreDisplay.enabled = false;
        }
        else
        {
            highScoreDisplay.text = $"High Score: {highScore}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
}
