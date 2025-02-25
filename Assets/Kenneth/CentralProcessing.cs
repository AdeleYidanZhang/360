using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralProcessing : MonoBehaviour
{
    public CamSwitch VisualPawns;
    public SceneDirector levelChange;

    public void hallwaySetting()
    {
        VisualPawns.Direction1();
    }

    public void roomSetting()
    {
        VisualPawns.ChibiHall();
    }
}