using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LifeManager : MonoBehaviour
{
    public GameObject[] Hearts;
    private HighScoreHolder _highScore;
    public Canvas _endCanvas;
    public Canvas _pauseCanvas;

    private int _heartCounter = 3;
    private bool _pause;
    protected void Awake()
    {
        _endCanvas.enabled = false;
        _pauseCanvas.enabled = false;
        _highScore = FindObjectOfType<HighScoreHolder>();
        _pause = false;
    }
    public void PlayerHit()
    {
        _heartCounter--;
        CheckHeats();
    }

    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _pause = !_pause;
            {
                if(_pause == true)
                {
                    Time.timeScale = 0;
                    _pauseCanvas.enabled = true;
                }
                else if(_pause == false)
                {
                    Time.timeScale = 1;
                    _pauseCanvas.enabled = false;
                }
                Debug.Log(Time.timeScale);
            }
        }
    }
    // disables hearts based if the ship has been hit;
    protected void CheckHeats()
    {
        if(_heartCounter == 3)
        {
            Hearts[Hearts.Length].SetActive(true); 
        }
        if(_heartCounter == 2)
        {
            Hearts[0].SetActive(true); Hearts[1].SetActive(true); Hearts[2].SetActive(false);
        }
        if (_heartCounter == 1)
        {
            Hearts[0].SetActive(true); Hearts[1].SetActive(false); Hearts[2].SetActive(false);
        }
        if(_heartCounter == 0)
        {
            Hearts[0].SetActive(false); Hearts[1].SetActive(false); Hearts[2].SetActive(false);
            _highScore.SyncHighScore();
            _endCanvas.enabled = true;
            StartCoroutine(EndGame());
            
        }
      
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
    

   
}
