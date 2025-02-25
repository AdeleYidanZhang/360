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

    public SceneDirector director;
    public MasterInstance mainProcess;
    public HallwayPlayerMovement player;
    public UIManager eyes;
    public string sceneName;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        director.positionSaving.Add(sceneName, Floor2Door1.transform.position);
    }

    void Start()
    {
        eyes.Direction1();
        mainProcess = (MasterInstance)FindAnyObjectByType(typeof(MasterInstance));
        MasterInstance.loadPersistentLevel();
        player.transform.position = mainProcess.lastPositionHallway;
    }

    private void Update()
    {
        mainProcess.lastPositionHallway = player.transform.position;
    }

    public void FromHall1ToHall2()
    {
        player.transform.position = Floor2Door1.transform.position;
        eyes.Direction2();
    }

    public void FromHall2ToHall1()
    {
        player.transform.position = Floor1Door1.transform.position;
        eyes.Direction1();
    }

    public void FromHall2ToRoom()
    {
        director.EnterRoom();
    }
}
