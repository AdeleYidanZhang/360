using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Hallway");
        PlayerPrefs.SetFloat("HallPlayerX", -26f);
        PlayerPrefs.SetFloat("HallPlayerY", 0f);
        PlayerPrefs.SetFloat("HallPlayerZ", 0f);

        PlayerPrefs.SetFloat("HallCameraLocationX", 0f);
        PlayerPrefs.SetFloat("HallCameraLocationY", 0f);
        PlayerPrefs.SetFloat("HallCameraLocationZ", -30f);

        PlayerPrefs.SetFloat("RoomPlayerX", -6f);
        PlayerPrefs.SetFloat("RoomPlayerY", 16f);
        PlayerPrefs.SetFloat("RoomPlayerZ", 0f);
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
