using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CamSwitch : MonoBehaviour
{

    public GameObject EyeForward;
    public GameObject EyeRight;
    public GameObject EyeBack;
    public GameObject EyeLeft;

    public GameObject DirectionForward;
    public GameObject DirectionRight;
    public GameObject DirectionBack;
    public GameObject DirectionLeft;

    public GameObject DirectionForwardFade;
    public GameObject DirectionRightFade;
    public GameObject DirectionBackFade;
    public GameObject DirectionLeftFade;

    private bool leftToRightIfTrue;

    void Start()
    {
        // Start Forward Facing Perspecting. So F and B
        leftToRightIfTrue = false;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && leftToRightIfTrue)
        {
            DirectionForward.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W) && leftToRightIfTrue)
        {
            DirectionForward.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.A) && !leftToRightIfTrue)
        {
            DirectionLeft.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.A) && !leftToRightIfTrue)
        {
            DirectionLeft.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S) && leftToRightIfTrue)
        {
            DirectionBack.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.S) && leftToRightIfTrue)
        {
            DirectionBack.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.D) && !leftToRightIfTrue)
        {
            DirectionRight.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.D) && !leftToRightIfTrue)
        {
            DirectionRight.SetActive(false);
        }
    }

    public void Direction1()
    {
        //CamManager.SwitchCamera(cam1);
        leftToRightIfTrue = false;

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
        //CamManager.SwitchCamera(cam2);
        leftToRightIfTrue = true;

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
        //CamManager.SwitchCamera(cam3);
        leftToRightIfTrue = false;

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
        //CamManager.SwitchCamera(cam4);
        leftToRightIfTrue = true;

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

    public void ChibiHall()
    {
        //CamManager.SwitchCamera(cam4);

        EyeForward.SetActive(false);
        EyeRight.SetActive(false);
        EyeBack.SetActive(false);
        EyeLeft.SetActive(false);

        DirectionForward.SetActive(false);
        DirectionForwardFade.SetActive(true);
        DirectionRight.SetActive(false);
        DirectionRightFade.SetActive(true);
        DirectionBack.SetActive(false);
        DirectionBackFade.SetActive(true);
        DirectionLeft.SetActive(false);
        DirectionLeftFade.SetActive(true);
    }
}
