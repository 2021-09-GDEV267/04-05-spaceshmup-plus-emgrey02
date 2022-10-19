using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text text;
    private int score;

    private void Awake()
    {
        score = 0;
        text = GetComponent<Text>();
        Main.enemyDestroyed += UpdateScore;
        UpdateText();
    }

    private void UpdateScore(Enemy e)
    {
        string enemyName = e.gameObject.name;
        if (enemyName.Contains("0"))
        {
            score += 5;
        } else if (enemyName.Contains("1"))
        {
            score += 10;
        } else if (enemyName.Contains ("2"))
        {
            score += 15;
        } else if (enemyName.Contains("3"))
        {
            score += 20;
        } else if (enemyName.Contains("4"))
        {
            score += 30;
        }
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = "Score: " + score;
    }
}
