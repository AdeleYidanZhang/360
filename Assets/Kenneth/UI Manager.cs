using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
    public int director;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Hallway")
        {
            Direction1();
        }

        if (SceneManager.GetActiveScene().name == "Room")
        {
            ChibiHall();
        }
    }

    // Update is called once per frame
    void Update()
    {
        director = PlayerPrefs.GetInt("DirectionCoordiator");
        HallwayDirectionCoordinator(director);

        if (leftToRightIfTrue && !inRoom)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                DirectionForward.SetEnabled(true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                DirectionForward.SetEnabled(false);
                if (Input.GetKeyDown(KeyCode.S))
                {
                    DirectionBack.SetEnabled(true);
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    DirectionBack.SetEnabled(false);
                }
            }
            else if (!leftToRightIfTrue && !inRoom)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    DirectionLeft.SetEnabled(true);
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    DirectionLeft.SetEnabled(false);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    DirectionRight.SetEnabled(true);
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    DirectionRight.SetEnabled(false);
                }
            }
            else if (inRoom)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    DirectionForward.SetEnabled(true);
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    DirectionForward.SetEnabled(false);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    DirectionBack.SetEnabled(true);
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    DirectionBack.SetEnabled(false);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    DirectionLeft.SetEnabled(true);
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    DirectionLeft.SetEnabled(false);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    DirectionRight.SetEnabled(true);
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    DirectionRight.SetEnabled(false);
                }
            }
        }
    }

    public void HallwayDirectionCoordinator(int direction)
    {
        if (direction == 1)
        {
            Direction1();
        }
        if (direction == 2)
        {
            Direction2();
        }
        if (direction == 3)
        {
            Direction3();
        }
        if (direction == 4)
        {
            Direction4();
        }
    }

    public void Direction1()
    {
        leftToRightIfTrue = true;
        inRoom = false;


        EyeForward.SetEnabled(false);
        EyeRight.SetEnabled(false);
        EyeBack.SetEnabled(false);
        EyeLeft.SetEnabled(true);

        DirectionForward.SetEnabled(false);
        DirectionForwardFade.SetEnabled(true);
        DirectionRight.SetEnabled(false);
        DirectionRightFade.SetEnabled(false);
        DirectionBack.SetEnabled(false);
        DirectionBackFade.SetEnabled(true);
        DirectionLeft.SetEnabled(false);
        DirectionLeftFade.SetEnabled(false);
    }

    public void Direction2()
    {
        leftToRightIfTrue = false;
        inRoom = false;

        EyeForward.SetEnabled(false);
        EyeRight.SetEnabled(false);
        EyeBack.SetEnabled(true);
        EyeLeft.SetEnabled(false);

        DirectionForward.SetEnabled(false);
        DirectionForwardFade.SetEnabled(false);
        DirectionRight.SetEnabled(false);
        DirectionRightFade.SetEnabled(true);
        DirectionBack.SetEnabled(false);
        DirectionBackFade.SetEnabled(false);
        DirectionLeft.SetEnabled(false);
        DirectionLeftFade.SetEnabled(true);
    }

    public void Direction3()
    {
        leftToRightIfTrue = false;
        inRoom = false;

        EyeForward.SetEnabled(false);
        EyeRight.SetEnabled(true);
        EyeBack.SetEnabled(false);
        EyeLeft.SetEnabled(false);

        DirectionForward.SetEnabled(false);
        DirectionForwardFade.SetEnabled(true);
        DirectionRight.SetEnabled(false);
        DirectionRightFade.SetEnabled(false);
        DirectionBack.SetEnabled(false);
        DirectionBackFade.SetEnabled(true);
        DirectionLeft.SetEnabled(false);
        DirectionLeftFade.SetEnabled(false);
    }

    public void Direction4()
    {
        leftToRightIfTrue = true;
        inRoom = false;


        EyeForward.SetEnabled(true);
        EyeRight.SetEnabled(false);
        EyeBack.SetEnabled(false);
        EyeLeft.SetEnabled(false);

        DirectionForward.SetEnabled(false);
        DirectionForwardFade.SetEnabled(false);
        DirectionRight.SetEnabled(false);
        DirectionRightFade.SetEnabled(true);
        DirectionBack.SetEnabled(false);
        DirectionBackFade.SetEnabled(false);
        DirectionLeft.SetEnabled(false);
        DirectionLeftFade.SetEnabled(true);
    }

    public void ChibiHall()
    {
        leftToRightIfTrue = false;
        inRoom = true;

        EyeForward.SetEnabled(false);
        EyeRight.SetEnabled(false);
        EyeBack.SetEnabled(false);
        EyeLeft.SetEnabled(false);

        DirectionForward.SetEnabled(false);
        DirectionForwardFade.SetEnabled(true);
        DirectionRight.SetEnabled(false);
        DirectionRightFade.SetEnabled(true);
        DirectionBack.SetEnabled(false);
        DirectionBackFade.SetEnabled(true);
        DirectionLeft.SetEnabled(false);
        DirectionLeftFade.SetEnabled(true);
    }
}
