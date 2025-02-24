using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Hallway");
    }

    public void EnterHallway()
    {
        SceneManager.LoadScene("Hallway");
    }

    public void EnterRoom()
    {
        SceneManager.LoadScene("Room");
    }
}
