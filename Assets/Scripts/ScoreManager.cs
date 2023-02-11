using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Button resetButton;
    private int score = 0;
    private int highScore = 0;

    private void Awake()
    {
        scoreManager = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }
    
    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString();
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
            highScoreText.text = highScore.ToString();
            
        }
    }
    
    public void LosePoint()
    {
        score--;
        scoreText.text = score.ToString();
    }
    
    public void ErasePoints()
    {
        score = 0;
        scoreText.text = score.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        PlayerPrefs.Save();
        UpdateHighscoreUI();
    }

    public void UpdateHighscoreUI()
    {
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = highScore.ToString();
    }
}
