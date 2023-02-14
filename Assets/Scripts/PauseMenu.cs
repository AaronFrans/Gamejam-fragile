using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool _isGamePaused = false;

    [SerializeField]
    private GameObject _pauseMenuUI = null;

    // Start is called before the first frame update
    void Start()
    {
        //_pauseMenuUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Fuck Unity");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("It's shit");

            if (_isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        _isGamePaused = true;
    }

    public void ResumeGame()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        _isGamePaused = false;
    }
}
