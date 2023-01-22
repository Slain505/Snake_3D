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
    int score = 0;

    private void Awake()
    {
        scoreManager = this;
    }

    void Start()
    {
        scoreText.text = score.ToString(); 
    }
    
    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
