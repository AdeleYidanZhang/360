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

    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;

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
        CamManager.SwitchCamera(cam1);
        transform.position = wall1.transform.position;

        EyeForward.SetActive(false);
        EyeRight.SetActive(false);
        EyeBack.SetActive(false);
        EyeLeft.SetActive(true);

        DirectionForward.SetActive(true);
        DirectionForwardFade.SetActive(true);
        DirectionRight.SetActive(false);
        DirectionRightFade.SetActive(false);
        DirectionBack.SetActive(true);
        DirectionBackFade.SetActive(true);
        DirectionLeft.SetActive(false);
        DirectionLeftFade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("NorthCamera")) // North
        {
            CamManager.SwitchCamera(cam1);
            transform.position = wall1.transform.position;

            EyeForward.SetActive(false);
            EyeRight.SetActive(false);
            EyeBack.SetActive(false);
            EyeLeft.SetActive(true);

            DirectionForward.SetActive(true);
            DirectionForwardFade.SetActive(true);
            DirectionRight.SetActive(false);
            DirectionRightFade.SetActive(false);
            DirectionBack.SetActive(true);
            DirectionBackFade.SetActive(true);
            DirectionLeft.SetActive(false);
            DirectionLeftFade.SetActive(false);
        }

        if (Input.GetButtonDown("EastCamera")) // East
        {
            CamManager.SwitchCamera(cam2);
            transform.position = wall2.transform.position;

            EyeForward.SetActive(false);
            EyeRight.SetActive(false);
            EyeBack.SetActive(true);
            EyeLeft.SetActive(false);

            DirectionForward.SetActive(false);
            DirectionForwardFade.SetActive(false);
            DirectionRight.SetActive(true);
            DirectionRightFade.SetActive(true);
            DirectionBack.SetActive(false);
            DirectionBackFade.SetActive(false);
            DirectionLeft.SetActive(true);
            DirectionLeftFade.SetActive(true);
        }
         
        if (Input.GetButtonDown("SouthCamera")) // South
        {
            CamManager.SwitchCamera(cam3);
            transform.position = wall3.transform.position;

            EyeForward.SetActive(false);
            EyeRight.SetActive(true);
            EyeBack.SetActive(false);
            EyeLeft.SetActive(false);

            DirectionForward.SetActive(true);
            DirectionForwardFade.SetActive(true);
            DirectionRight.SetActive(false);
            DirectionRightFade.SetActive(false);
            DirectionBack.SetActive(true);
            DirectionBackFade.SetActive(true);
            DirectionLeft.SetActive(false);
            DirectionLeftFade.SetActive(false);
        }

        if (Input.GetButtonDown("WestCamera")) // West
        {
            CamManager.SwitchCamera(cam4);
            transform.position = wall4.transform.position;

            EyeForward.SetActive(true);
            EyeRight.SetActive(false);
            EyeBack.SetActive(false);
            EyeLeft.SetActive(false);

            DirectionForward.SetActive(false);
            DirectionForwardFade.SetActive(false);
            DirectionRight.SetActive(true);
            DirectionRightFade.SetActive(true);
            DirectionBack.SetActive(false);
            DirectionBackFade.SetActive(false);
            DirectionLeft.SetActive(true);
            DirectionLeftFade.SetActive(true);
        }
    }
}
