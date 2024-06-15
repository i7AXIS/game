using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void StartGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenMenu () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame () {
        Application.Quit();
    }


}
