using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text highScore;
    private int _highScoreInt;

    public int HighScoreInt
    {
        get { return _highScoreInt; }
        set 
        { 
            _highScoreInt = value;
            UpdateHighScoreText();
            UpdatePlayerPrefs();
        }
    }

    void Awake()
    {
        ScoreDisplay.scoreUpdated += UpdateHighScore;
        highScore = GetComponent<Text>();
    }

    private void Start()
    {
        
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScoreInt = PlayerPrefs.GetInt("HighScore");
        } else
        {
            HighScoreInt = 0;
        }
    }
    public void UpdateHighScore(int score)
    {
        if (score > _highScoreInt)
        {
            HighScoreInt = score;
        }
    }
    public void UpdateHighScoreText()
    {
        highScore.text = "High Score: " + HighScoreInt;
    }

    private void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetInt("HighScore", HighScoreInt);
    }
}
