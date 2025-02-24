using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerChange : MonoBehaviour
{

    public HallwayPlayerMovement PlayerHall;
    public TopDownPlayerMovement PlayerChibi;

    public void chibiPlayerActive()
    {
        PlayerHall.enabled = false;
        PlayerChibi.enabled = true;
    }

    public void hallwayPlayerActive()
    {
        PlayerHall.enabled = true;
        PlayerChibi.enabled = false;
    }
}
