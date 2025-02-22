using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralProcessing : MonoBehaviour
{
    public Interactible gate1;
    public Interactible gate2;
    public Interactible gate3;
    public Interactible gate4;
    public Interactible chibiGate;

    public PlayerChange PlayerPawns;
    public CamSwitch VisualPawns;

    public void Awake()
    {
        PlayerPawns.PlayerHall.enabled = true;
        PlayerPawns.PlayerChibi.enabled = false;
    }

    public void Level1to2()
    {
        PlayerPawns.PlayerHall.enabled = true;
        PlayerPawns.PlayerChibi.enabled = false;
        PlayerPawns.PlayerHall.transform.position = gate2.transform.position;
        VisualPawns.Direction2();
    }

    public void Level2to1()
    {
        PlayerPawns.PlayerHall.enabled = true;
        PlayerPawns.PlayerChibi.enabled = false;
        PlayerPawns.PlayerHall.transform.position = gate1.transform.position;
        VisualPawns.Direction1();
    }

    public void Level2to3()
    {
        PlayerPawns.PlayerHall.enabled = true;
        PlayerPawns.PlayerChibi.enabled = false;
        PlayerPawns.PlayerHall.transform.position = gate3.transform.position;
        VisualPawns.Direction3();
    }

    public void Level3to2()
    {
        PlayerPawns.PlayerHall.enabled = true;
        PlayerPawns.PlayerChibi.enabled = false;
        PlayerPawns.PlayerHall.transform.position = gate2.transform.position;
        VisualPawns.Direction2();
    }

    public void Level3to4()
    {
        PlayerPawns.PlayerHall.enabled = true;
        PlayerPawns.PlayerChibi.enabled = false;
        PlayerPawns.PlayerHall.transform.position = gate4.transform.position;
        VisualPawns.Direction4();
    }

    public void Level4to3()
    {
        PlayerPawns.PlayerHall.enabled = true;
        PlayerPawns.PlayerChibi.enabled = false;
        PlayerPawns.PlayerHall.transform.position = gate3.transform.position;
        VisualPawns.Direction3();
    }

    public void Level4toChibi()
    {
        PlayerPawns.PlayerHall.enabled = true;
        PlayerPawns.PlayerChibi.enabled = false;
        PlayerPawns.PlayerHall.transform.position = chibiGate.transform.position;
        VisualPawns.ChibiHall();
    }

    public void LevelChibito4()
    {
        PlayerPawns.PlayerHall.enabled = false;
        PlayerPawns.PlayerChibi.enabled = true;
        PlayerPawns.PlayerHall.transform.position = gate4.transform.position;
        VisualPawns.Direction4();
    }
}