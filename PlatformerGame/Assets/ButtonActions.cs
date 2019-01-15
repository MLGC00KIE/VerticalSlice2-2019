using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OpenSettings()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
