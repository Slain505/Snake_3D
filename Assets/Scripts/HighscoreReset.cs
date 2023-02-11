using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreReset : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Reset);
    }
    
    private void Reset()
    {
        scoreManager.ResetHighscore();
        Debug.Log("Highscore reset");
    }
}
