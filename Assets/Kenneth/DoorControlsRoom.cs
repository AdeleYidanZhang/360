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
    public string sceneName;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        director.positionSaving.Add(sceneName, Floor2Door1.transform.position);
    }

    void Start()
    {
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
    }

    public void FromHall2ToHall1()
    {
        player.transform.position = Floor1Door1.transform.position;
    }

    public void FromHall2ToRoom()
    {
        director.EnterRoom();
    }
}
