using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas _mainMenuCanvas;
    public Canvas _scoreCanvas;
    public GameObject _instructionsCanvas;
    public string _levelToLoad;
    public AudioClip _buttonPressed;

    private AudioSource _audioSource;
    private HighScoreHolder _highScoreHolder;

    private float _switchCanvas = 0;
    protected void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _scoreCanvas.enabled = false;
        _instructionsCanvas.SetActive(false);
        _highScoreHolder = FindObjectOfType<HighScoreHolder>();
        _switchCanvas = 0;
    }
    //syncs highscore for the previous score tab;
    protected void Start()
    {
        _highScoreHolder.SyncHighScoreInMainMenu();
    }
    // activates the right canvas based on the float value switchcanvas;
    protected void Update()
    {
        if(_switchCanvas == 0)
        {
            _mainMenuCanvas.enabled = true; _instructionsCanvas.SetActive(false); _scoreCanvas.enabled = false;
        }
        if(_switchCanvas == 1)
        {
            _mainMenuCanvas.enabled = false; _instructionsCanvas.SetActive(true); _scoreCanvas.enabled = false;
        }
        if(_switchCanvas == 2)
        {
            _mainMenuCanvas.enabled = false; _instructionsCanvas.SetActive(false); _scoreCanvas.enabled = true;
        }
    }

    protected void ButtonSound()
    {
        _audioSource.PlayOneShot(_buttonPressed);
    }

    public void Play()
    {
        ButtonSound();
        SceneManager.LoadScene(_levelToLoad);
        Debug.Log(_levelToLoad);
    }

    public void Instructions()
    {
        ButtonSound();
        _switchCanvas = 1;
        Debug.Log(_switchCanvas);
    }

    public void Settings()
    {
        ButtonSound();
        _switchCanvas = 2;
        Debug.Log(_switchCanvas);
    }

    public void BackToMainMenu()
    {
        ButtonSound();
        _switchCanvas = 0;
        Debug.Log(_switchCanvas);
    }

    public void Exit()
    {
        ButtonSound();
        Debug.Log("Exit");
        Application.Quit();
    }
}
