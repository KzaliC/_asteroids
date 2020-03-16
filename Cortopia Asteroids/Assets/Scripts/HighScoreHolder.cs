using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreHolder : MonoBehaviour
{
    private static int HighScore;
    private int _checkHighScore;
    private static HighScoreHolder _highScoreHolder;
    protected void Start()
    {      
        _checkHighScore = 0;
        DontDestroyOnLoad(this);
        if (_highScoreHolder == null)
        {
            _highScoreHolder = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SyncHighScoreInMainMenu()
    {
        TextMeshProUGUI HighScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<TextMeshProUGUI>();
        HighScoreText.text = "HighScore " + HighScore;
    }
    // if your in the game scene this function syncs the score in the current session;
    public void SyncScoreInGame()
    {
        TextMeshProUGUI HighScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<TextMeshProUGUI>();
        HighScoreText.text = "HighScore " + HighScore;
        TextMeshProUGUI CurrentScore = GameObject.FindGameObjectWithTag("CurrentScoreGame").GetComponent<TextMeshProUGUI>();
        CurrentScore.text = "Current Score " + _checkHighScore;
    }
    // sees if the scorehandler exists if does exist, it syncs the high score with the current score;
    public void SyncHighScore()
    {
        ScoreHandler scoreHandler = FindObjectOfType<ScoreHandler>();
        if(scoreHandler == null)
        {
            scoreHandler = null;
        }
        else if(scoreHandler != null)
        {
            _checkHighScore = scoreHandler._currentScore;
            HighScore = _checkHighScore;
            SyncScoreInGame();
        }
    }
}
