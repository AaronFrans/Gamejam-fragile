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
        ResetPlayer();
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

    private void ResetPlayer()
    {

        _playerMovement._hasUnlockedDoubleJump = false;
        _playerMovement._movementSpeed = 6.0f;
        _playerMovement. _jumpforce = 3.0f;
        BreakableObject._copperValue = 100;
        BreakableObject._silverValue = 500;
        BreakableObject._goldValue = 1000;
        _playerAttack._playerAttackPower = 0;
    }
}
