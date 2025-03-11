using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControlsFinal : MonoBehaviour
{
    public Camera roomCam;

    public SceneDirector director;
    public MasterInstance mainProcess;
    public string sceneName;
    public TopDownPlayerMovement roomPlayer;

    public Canvas ending;
    public Canvas eyes;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        mainProcess = (MasterInstance)FindAnyObjectByType(typeof(MasterInstance));
        MasterInstance.loadPersistentLevel();
        roomPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("RoomPlayerX"), PlayerPrefs.GetFloat("RoomPlayerY"), PlayerPrefs.GetFloat("RoomPlayerZ"));
        roomCam.transform.position = new Vector3(PlayerPrefs.GetFloat("RoomCameraLocationX"), PlayerPrefs.GetFloat("RoomCameraLocationY"), PlayerPrefs.GetFloat("RoomCameraLocationZ"));
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("RoomPlayerX", roomPlayer.transform.position.x);
        PlayerPrefs.SetFloat("RoomPlayerY", roomPlayer.transform.position.y);
        PlayerPrefs.SetFloat("RoomPlayerZ", roomPlayer.transform.position.z);

        PlayerPrefs.SetFloat("RoomCameraLocationX", roomCam.transform.position.x);
        PlayerPrefs.SetFloat("RoomCameraLocationY", roomCam.transform.position.y);
        PlayerPrefs.SetFloat("RoomCameraLocationZ", roomCam.transform.position.z);
    }

    public void FromLivingRoomToEntrace()
    {
        PlayerPrefs.SetFloat("HallPlayerX", 19.2f);
        PlayerPrefs.SetFloat("HallPlayerY", 1.03f);
        PlayerPrefs.SetFloat("HallPlayerZ", 0f);

        PlayerPrefs.SetFloat("HallCameraLocationX", 0f);
        PlayerPrefs.SetFloat("HallCameraLocationY", 0f);
        PlayerPrefs.SetFloat("HallCameraLocationZ", -30f);

        director.EnterHallway();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
