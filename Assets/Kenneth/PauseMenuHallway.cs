using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHallway : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas MainUI;
    public HallwayPlayerMovement player;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
        MainUI.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        player.gameObject.SetActive(false);
        MainUI.gameObject.SetActive(false);
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        player.gameObject.SetActive(true);
        MainUI.gameObject.SetActive(true);
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Demo Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
