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

    public void hallToChibi()
    {
        PlayerHall.enabled = false;
        PlayerChibi.enabled = true;
        cameraChibi.enabled = true;
        cameraHall.enabled = false;
    }

    public void chibiToHall()
    {
        PlayerHall.enabled = true;
        PlayerChibi.enabled = false;
        cameraChibi.enabled = false;
        cameraHall.enabled = true;
    }
}
