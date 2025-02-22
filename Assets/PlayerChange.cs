using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerChange : MonoBehaviour
{

    public PlayerMovement PlayerHall;
    public TopDownPlayerMovement PlayerChibi;

    public CinemachineVirtualCamera cameraHall;
    public CinemachineVirtualCamera cameraChibi;

    public void chibiPlayerActive()
    {
        PlayerHall.enabled = false;
        PlayerChibi.enabled = true;
        CamManager.SwitchCamera(cameraChibi);
    }

    public void hallwayPlayerActive()
    {
        PlayerHall.enabled = true;
        PlayerChibi.enabled = false;
        CamManager.SwitchCamera(cameraHall);
    }
}
