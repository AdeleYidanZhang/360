using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorControlsRoom : MonoBehaviour
{
    public Interactible Floor1Door1;
    public Interactible Floor2Door1;
    public Interactible Floor2Door2;

    public SceneDirector director;
    public MasterInstance mainProcess;

    void Start()
    {
        mainProcess = (MasterInstance)FindAnyObjectByType(typeof(MasterInstance));
    }

    public void FromHall1ToHall2()
    {
        mainProcess.hallPlayerClone.transform.position = Floor2Door1.transform.position;
    }

    public void FromHall2ToHall1()
    {
        mainProcess.hallPlayerClone.transform.position = Floor1Door1.transform.position;
    }

    public void FromHall2ToRoom()
    {
        director.EnterRoom();
    }
}
