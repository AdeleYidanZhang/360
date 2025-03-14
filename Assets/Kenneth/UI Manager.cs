using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image EyeForward;
    public Image EyeRight;
    public Image EyeBack;
    public Image EyeLeft;
    public Image DirectionForward;
    public Image DirectionRight;
    public Image DirectionBack;
    public Image DirectionLeft;
    public Image DirectionForwardFade;
    public Image DirectionRightFade;
    public Image DirectionBackFade;
    public Image DirectionLeftFade;

    private bool leftToRightIfTrue;
    private bool inRoom;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("DirectionCoordiator") == 1)
        {
            Direction1();
        }
        if (PlayerPrefs.GetInt("DirectionCoordiator") == 2)
        {
            Direction2();
        }
        if (PlayerPrefs.GetInt("DirectionCoordiator") == 3)
        {
            Direction3();
        }
        if (PlayerPrefs.GetInt("DirectionCoordiator") == 4)
        {
            Direction4();
        }
        if (PlayerPrefs.GetInt("DirectionCoordiator") == 5)
        {
            ChibiHall();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (leftToRightIfTrue && !inRoom)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                DirectionForward.enabled = true;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                DirectionForward.enabled = false;
                if (Input.GetKeyDown(KeyCode.S))
                {
                    DirectionBack.enabled = true;
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    DirectionBack.enabled = false;
                }
            }
            else if (!leftToRightIfTrue && !inRoom)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    DirectionLeft.enabled = true;
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    DirectionLeft.enabled = false;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    DirectionRight.enabled = true;
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    DirectionRight.enabled = false;
                }
            }
            else if (inRoom)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    DirectionForward.enabled = true;
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    DirectionForward.enabled = false;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    DirectionBack.enabled = true;
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    DirectionBack.enabled = false;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    DirectionLeft.enabled = true;
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    DirectionLeft.enabled = false;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    DirectionRight.enabled = true;
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    DirectionRight.enabled = false;
                }
            }
        }
    }

    public void Direction1()
    {
        leftToRightIfTrue = true;
        inRoom = false;


        EyeForward.enabled = false;
        EyeRight.enabled = false;
        EyeBack.enabled = false;
        EyeLeft.enabled = true;

        DirectionForward.enabled = false;
        DirectionForwardFade.enabled = true;
        DirectionRight.enabled = false;
        DirectionRightFade.enabled = false;
        DirectionBack.enabled = false;
        DirectionBackFade.enabled = true;
        DirectionLeft.enabled = false;
        DirectionLeftFade.enabled = false;
    }

    public void Direction2()
    {
        leftToRightIfTrue = false;
        inRoom = false;

        EyeForward.enabled = false;
        EyeRight.enabled = false;
        EyeBack.enabled = true;
        EyeLeft.enabled = false;

        DirectionForward.enabled = false;
        DirectionForwardFade.enabled = false;
        DirectionRight.enabled = false;
        DirectionRightFade.enabled = true;
        DirectionBack.enabled = false;
        DirectionBackFade.enabled = false;
        DirectionLeft.enabled = false;
        DirectionLeftFade.enabled = true;
    }

    public void Direction3()
    {
        leftToRightIfTrue = false;
        inRoom = false;

        EyeForward.enabled = false;
        EyeRight.enabled = true;
        EyeBack.enabled = false;
        EyeLeft.enabled = false;

        DirectionForward.enabled = false;
        DirectionForwardFade.enabled = true;
        DirectionRight.enabled = false;
        DirectionRightFade.enabled = false;
        DirectionBack.enabled = false;
        DirectionBackFade.enabled = true;
        DirectionLeft.enabled = false;
        DirectionLeftFade.enabled = false;
    }

    public void Direction4()
    {
        leftToRightIfTrue = true;
        inRoom = false;


        EyeForward.enabled = true;
        EyeRight.enabled = false;
        EyeBack.enabled = false;
        EyeLeft.enabled = false;

        DirectionForward.enabled = false;
        DirectionForwardFade.enabled = false;
        DirectionRight.enabled = false;
        DirectionRightFade.enabled = true;
        DirectionBack.enabled = false;
        DirectionBackFade.enabled = false;
        DirectionLeft.enabled = false;
        DirectionLeftFade.enabled = true;
    }

    public void ChibiHall()
    {
        leftToRightIfTrue = false;
        inRoom = true;

        EyeForward.enabled = false;
        EyeRight.enabled = false;
        EyeBack.enabled = false;
        EyeLeft.enabled = false;

        DirectionForward.enabled = false;
        DirectionForwardFade.enabled = true;
        DirectionRight.enabled = false;
        DirectionRightFade.enabled = true;
        DirectionBack.enabled = false;
        DirectionBackFade.enabled = true;
        DirectionLeft.enabled = false;
        DirectionLeftFade.enabled = true;
    }
}
