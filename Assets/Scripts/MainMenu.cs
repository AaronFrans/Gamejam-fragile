using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject musicSettings;

    private void Start()
    {
        musicSettings.SetActive(false);
        
    }
    public void StartGame()
    {

        PlayerPrefs.DeleteAll();
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("MainLevel");

    }

    public void OpenSoundSettings()
    {
        mainMenu.SetActive(false);
        musicSettings.SetActive(true);

    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        musicSettings.SetActive(false);
    }
}
