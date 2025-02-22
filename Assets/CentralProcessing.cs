using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralProcessing : MonoBehaviour
{
    public PlayerChange PlayerPawns;
    public CamSwitch VisualPawns;

    public void Awake()
=======
    public Interactible gate1To2;
    public Interactible gate2To1;
    public Interactible gate2ToRoom;
    public Interactible gateRoomTo2;

    private Vector3 gate1To2Pos;
    private Vector3 gate2To1Pos;
    private Vector3 gate2ToRoomPos;
    private Vector3 gateRoomTo2Pos;

    void Awake()
    {
        doorPressedHallway();
    }

    void Start()
    {
        gate1To2Pos = new Vector3(gate1To2.transform.position.x, gate1To2.transform.position.y, gate1To2.transform.position.z);
        gate2To1Pos = new Vector3(gate2To1.transform.position.x, gate2To1.transform.position.y, gate2To1.transform.position.z);
        gate2ToRoomPos = new Vector3(gate2ToRoom.transform.position.x, gate2ToRoom.transform.position.y, gate2ToRoom.transform.position.z);
        gateRoomTo2Pos = new Vector3(gateRoomTo2.transform.position.x, gateRoomTo2.transform.position.y, gateRoomTo2.transform.position.z);
    }

    public void DoorGate1to2()
    {
        transform.position = gate1To2Pos;
        Debug.Log("Moving to Floor 2");
    }

    public void DoorGate2to1()
    {
        transform.position = gate2To1Pos;
        Debug.Log("Moving to Floor 1");
    }

    public void DoorGate2toRoom()
    {
        transform.position = gate2ToRoomPos;
        Debug.Log("Moving to Floor Room");
    }

    public void DoorGateRoomto2()
    {
        transform.position = gateRoomTo2Pos;
        Debug.Log("Moving to Floor 2");
    }


    public void doorPressedHallway()
    {
        PlayerPawns.hallwayPlayerActive();
        VisualPawns.Direction1();
    }

    public void doorPressedChibi()
    {
        PlayerPawns.hallwayPlayerActive();
        VisualPawns.Direction2();
    }
}