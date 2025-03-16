using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControlsHallway : MonoBehaviour
{
    public Camera hallwayCam;

    public SceneDirector director;
    public MasterInstance mainProcess;
    public HallwayPlayerMovement hallPlayer;
    public Canvas eyes;
    public string sceneName;
    public Pause_Menu pause;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        if (pause.isPaused)
        {
            eyes.gameObject.SetActive(false);
            eyes.gameObject.SetActive(false);
        }

        mainProcess = (MasterInstance)FindAnyObjectByType(typeof(MasterInstance));
        MasterInstance.loadPersistentLevel();
        PlayerPrefs.SetInt("closetDoorLock", 1);
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("HallPlayerX", hallPlayer.transform.position.x);
        PlayerPrefs.SetFloat("HallPlayerY", hallPlayer.transform.position.y);
        PlayerPrefs.SetFloat("HallPlayerZ", hallPlayer.transform.position.z);

        PlayerPrefs.SetFloat("HallCameraLocationX", hallwayCam.transform.position.x);
        PlayerPrefs.SetFloat("HallCameraLocationY", hallwayCam.transform.position.y);
        PlayerPrefs.SetFloat("HallCameraLocationZ", hallwayCam.transform.position.z);
    }

    public void FromEntraceToLivingRoom()
    {
        PlayerPrefs.SetFloat("RoomPlayerX", 0f);
        PlayerPrefs.SetFloat("RoomPlayerY", -145f);
        PlayerPrefs.SetFloat("RoomPlayerZ", 0f);

        PlayerPrefs.SetFloat("RoomCameraLocationX", 0f);
        PlayerPrefs.SetFloat("RoomCameraLocationY", -100f);
        PlayerPrefs.SetFloat("RoomCameraLocationZ", -100f);
        PlayerPrefs.SetInt("DirectionCoordiator", 5);

        director.EnterRoom();
    }

    public void FromDemoEndToLivingRoom()
    {
        PlayerPrefs.SetFloat("RoomPlayerX", -60f);
        PlayerPrefs.SetFloat("RoomPlayerY", -85f);
        PlayerPrefs.SetFloat("RoomPlayerZ", 0f);

        PlayerPrefs.SetFloat("RoomCameraLocationX", 0f);
        PlayerPrefs.SetFloat("RoomCameraLocationY", -100f);
        PlayerPrefs.SetFloat("RoomCameraLocationZ", -100f);
        PlayerPrefs.SetInt("DirectionCoordiator", 5);

        director.EnterRoom();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
