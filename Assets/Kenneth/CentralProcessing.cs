using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralProcessing : MonoBehaviour
{

    public PlayerChange PlayerPawns;
    public CamSwitch VisualPawns;
    public SceneDirector levelChange;

    public bool RoomIfFalse;

    void Awake()
    {
        if (RoomIfFalse)
        {
            hallwaySetting();
        } else
        {
            roomSetting();
        }
    }

    public void hallwaySetting()
    {
        PlayerPawns.hallwayPlayerActive();
        VisualPawns.Direction1();
    }

    public void roomSetting()
    {
        PlayerPawns.chibiPlayerActive();
        VisualPawns.ChibiHall();
    }
}