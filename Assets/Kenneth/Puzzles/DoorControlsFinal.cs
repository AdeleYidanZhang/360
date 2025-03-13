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

    public GameObject puzzleClock;

    public Canvas ending;
    public Canvas eyes;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        puzzleClock.SetActive(true);
    }

    void Start()
    {
        mainProcess = (MasterInstance)FindAnyObjectByType(typeof(MasterInstance));
        MasterInstance.loadPersistentLevel();
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
        PlayerPrefs.SetFloat("HallPlayerX", 20f);
        PlayerPrefs.SetFloat("HallPlayerY", 1f);
        PlayerPrefs.SetFloat("HallPlayerZ", 0f);

        PlayerPrefs.SetFloat("HallCameraLocationX", 0f);
        PlayerPrefs.SetFloat("HallCameraLocationY", 0f);
        PlayerPrefs.SetFloat("HallCameraLocationZ", -30f);

        director.EnterHallway();
    }

    public void FromLivingRoomToDemoEnd()
    {
        PlayerPrefs.SetFloat("HallPlayerX", 30f);
        PlayerPrefs.SetFloat("HallPlayerY", -55f);
        PlayerPrefs.SetFloat("HallPlayerZ", 0f);

        PlayerPrefs.SetFloat("HallCameraLocationX", 0f);
        PlayerPrefs.SetFloat("HallCameraLocationY", -50f);
        PlayerPrefs.SetFloat("HallCameraLocationZ", -30f);

        director.EnterHallway();
    }

    public void OpenClockPuzzle()
    {
        puzzleClock.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
