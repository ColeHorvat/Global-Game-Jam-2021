using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public MouseLook mouseLook;
    public GameObject pauseMenuUI;

    void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gameIsPaused) {
                resume();
            } else {
                pause();
            }
        }
    }

    public void resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Resume");
        mouseLook.enabled = true;
    }

    void pause() {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        gameIsPaused = true;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void quitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
