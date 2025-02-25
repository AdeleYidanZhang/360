using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControlsRoom : MonoBehaviour
{
    public Interactible Floor1Door1;
    public Interactible Floor2Door1;
    public Interactible Floor2Door2;

    public Camera hallwayCam;

    public SceneDirector director;
    public MasterInstance mainProcess;
    public HallwayPlayerMovement hallPlayer;
    public UIManager eyes;
    public string sceneName;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        mainProcess = (MasterInstance)FindAnyObjectByType(typeof(MasterInstance));
        MasterInstance.loadPersistentLevel();
        hallPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("HallPlayerX"), PlayerPrefs.GetFloat("HallPlayerY"), PlayerPrefs.GetFloat("HallPlayerZ"));
        hallwayCam.transform.position = new Vector3(PlayerPrefs.GetFloat("HallCameraLocationX"), PlayerPrefs.GetFloat("HallCameraLocationY"), PlayerPrefs.GetFloat("HallCameraLocationZ"));

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

    public void FromHall1ToHall2()
    {
        hallPlayer.transform.position = Floor2Door1.transform.position;
        hallwayCam.transform.position = new Vector3(0f, -33.33f, -30f);
        eyes.Direction2();
    }

    public void FromHall2ToHall1()
    {
        hallPlayer.transform.position = Floor1Door1.transform.position;
        hallwayCam.transform.position = new Vector3(0f, 0f, -30f);
        eyes.Direction1();
    }

    public void FromHall2ToRoom()
    {
        director.EnterRoom();
    }
}
