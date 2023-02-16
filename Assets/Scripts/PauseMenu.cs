using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    static public bool _isGamePaused = false;

    [SerializeField]
    private GameObject _pauseMenuUI = null;

    [SerializeField]
    private GameObject _soundMenu = null;

    [SerializeField]
    private GameObject _GameGUI = null;


    // Start is called before the first frame update
    void Start()
    {
        if (_pauseMenuUI == null)
            Debug.Log("no _pauseMenuUI set");

        _pauseMenuUI.SetActive(false);
        _soundMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            if (_isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _pauseMenuUI.SetActive(true);
        _GameGUI.SetActive(false);
        Time.timeScale = 0;
        _isGamePaused = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        _isGamePaused = false;
        _GameGUI.SetActive(true);
        _soundMenu.SetActive(false);
    }

    public void OpenSoundSettings()
    {
        _pauseMenuUI.SetActive(false);
        
        _soundMenu.SetActive(true);
    }

    public void CloseSoundSettings() 
    {
        _pauseMenuUI.SetActive(true);
        _soundMenu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        _isGamePaused = false;
        SceneManager.LoadScene("StartMenu");
    }
}
