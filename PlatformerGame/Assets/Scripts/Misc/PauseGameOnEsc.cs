using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameOnEsc : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;

    private bool isPaused = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause(true);
            } else
            {
                Pause(false);
            }

        }
    }

    public void Pause(bool pause)
    {
        pauseMenu.SetActive(pause);
        isPaused = pause;
    }
}
