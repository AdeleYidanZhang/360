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

        PlayerPrefs.SetFloat("RoomPlayerX", 0f);
        PlayerPrefs.SetFloat("RoomPlayerY", -145f);
        PlayerPrefs.SetFloat("RoomPlayerZ", 0f);

        PlayerPrefs.SetFloat("RoomCameraLocationX", 0f);
        PlayerPrefs.SetFloat("RoomCameraLocationY", 100f);
        PlayerPrefs.SetFloat("RoomCameraLocationZ", -100f);
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
