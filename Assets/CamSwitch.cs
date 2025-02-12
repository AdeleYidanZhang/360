using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class CamSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public CinemachineVirtualCamera cam3;
    public CinemachineVirtualCamera cam4;

    public GameObject EyeForward;
    public GameObject EyeRight;
    public GameObject EyeBack;
    public GameObject EyeLeft;

    public GameObject gate1;
    public GameObject gate2;
    public GameObject gate3;
    public GameObject gate4;

    public GameObject DirectionForward;
    public GameObject DirectionRight;
    public GameObject DirectionBack;
    public GameObject DirectionLeft;

    public GameObject DirectionForwardFade;
    public GameObject DirectionRightFade;
    public GameObject DirectionBackFade;
    public GameObject DirectionLeftFade;

    void Start()
    {
        // Start Forward Facing Perspecting. So F and B
        Direction1();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            DirectionForward.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            DirectionForward.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            DirectionLeft.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            DirectionLeft.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            DirectionBack.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            DirectionBack.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DirectionRight.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            DirectionRight.SetActive(false);
        }
    }

    public void Direction1()
    {
        CamManager.SwitchCamera(cam1);
        transform.position = gate1.transform.position;

        EyeForward.SetActive(false);
        EyeRight.SetActive(false);
        EyeBack.SetActive(false);
        EyeLeft.SetActive(true);

        DirectionForward.SetActive(false);
        DirectionForwardFade.SetActive(true);
        DirectionRight.SetActive(false);
        DirectionRightFade.SetActive(false);
        DirectionBack.SetActive(false);
        DirectionBackFade.SetActive(true);
        DirectionLeft.SetActive(false);
        DirectionLeftFade.SetActive(false);
    }

    public void Direction2()
    {
        CamManager.SwitchCamera(cam2);
        transform.position = gate2.transform.position;

        EyeForward.SetActive(false);
        EyeRight.SetActive(false);
        EyeBack.SetActive(true);
        EyeLeft.SetActive(false);

        DirectionForward.SetActive(false);
        DirectionForwardFade.SetActive(false);
        DirectionRight.SetActive(false);
        DirectionRightFade.SetActive(true);
        DirectionBack.SetActive(false);
        DirectionBackFade.SetActive(false);
        DirectionLeft.SetActive(false);
        DirectionLeftFade.SetActive(true);
    }

    public void Direction3()
    {
        CamManager.SwitchCamera(cam3);
        transform.position = gate3.transform.position;

        EyeForward.SetActive(false);
        EyeRight.SetActive(true);
        EyeBack.SetActive(false);
        EyeLeft.SetActive(false);

        DirectionForward.SetActive(false);
        DirectionForwardFade.SetActive(true);
        DirectionRight.SetActive(false);
        DirectionRightFade.SetActive(false);
        DirectionBack.SetActive(false);
        DirectionBackFade.SetActive(true);
        DirectionLeft.SetActive(false);
        DirectionLeftFade.SetActive(false);
    }

    public void Direction4()
    {
        CamManager.SwitchCamera(cam4);
        transform.position = gate4.transform.position;

        EyeForward.SetActive(true);
        EyeRight.SetActive(false);
        EyeBack.SetActive(false);
        EyeLeft.SetActive(false);

        DirectionForward.SetActive(false);
        DirectionForwardFade.SetActive(false);
        DirectionRight.SetActive(false);
        DirectionRightFade.SetActive(true);
        DirectionBack.SetActive(false);
        DirectionBackFade.SetActive(false);
        DirectionLeft.SetActive(false);
        DirectionLeftFade.SetActive(true);
    }
}
