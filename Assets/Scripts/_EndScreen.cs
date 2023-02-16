using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _EndScreen : MonoBehaviour
{

  public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
