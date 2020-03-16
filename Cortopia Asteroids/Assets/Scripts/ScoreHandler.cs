using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ScoreHandler : MonoBehaviour
{
    [HideInInspector]
    public int _currentScore;
    private TextMeshProUGUI _currentScoreText;
   // private HighScoreHolder _highScoreHolder;
    protected void Awake()
    {
      //  _highScoreHolder = FindObjectOfType<HighScoreHolder>();
        _currentScoreText = GameObject.FindGameObjectWithTag("CurrentScore").GetComponent<TextMeshProUGUI>();
        _currentScore = 0;
        _currentScoreText.text = "Score: " + _currentScore;
    }

    protected void Update()
    {           
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            testFunction();
        }
    }
    public void AsteriodAddScore()
    {
        _currentScore++;
        Debug.Log(_currentScore);
        UpdateScore();
    }

    protected void UpdateScore()
    {
        _currentScoreText.text = "Score: " + _currentScore;
    }
    
    //just a test function for debug
    protected void testFunction()
    {
        SceneManager.LoadScene(0);
    }
}
