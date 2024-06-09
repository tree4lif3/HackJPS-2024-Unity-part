using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;

                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }

    public void Resume()
    {
        isPaused = false;

        Time.timeScale = 1;
        pauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("Resume");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
