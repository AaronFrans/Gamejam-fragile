using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void StartGame()
    {

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainLevel");
    }

}
