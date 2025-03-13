using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzleMaster : MonoBehaviour
{
    public ClockPuzzleMinute minuteHand;
    public ClockPuzzleHour hourHand;

    public Canvas puzzleHint;
    public Canvas eyeUI;

    public int closetDoor;
    public Camera roomCam;

    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        minuteHand.notWonYet = true;
        hourHand.notWonYet = true;
        puzzleHint.gameObject.SetActive(false);
        PlayerPrefs.SetInt("closetDoorLock", 1); // 1 is locked, 0 is unlocked
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() // NOTE: 12:00 IS 0. 9 IS 90. 6 IS 180. 3 IS -90
    {

        Debug.Log($"Minute Hand: {minuteHand.angle}, Hour Hand: {hourHand.angle}");

        if (minuteHand.angle >= 50f && minuteHand.angle <= 52f)
        {
            minuteHand.angle = 51f;
            minuteHand.notWonYet = false;
        }

        if (hourHand.angle >= -142f && hourHand.angle <= -140f)
        {
            hourHand.angle = -141f;
            hourHand.notWonYet = false;
        }

        if (!hourHand.notWonYet && !minuteHand.notWonYet)
        {
            winText.SetActive(true);
            PlayerPrefs.SetInt("closetDoorLock", 0);
        }
    }

    public void ClosePuzzle()
    {
        puzzleHint.gameObject.SetActive(false);
        gameObject.SetActive(false);
        roomCam.transform.position = new Vector3(0, -100f, -100);
        eyeUI.gameObject.SetActive(true);
    }

    public void OpenPuzzle()
    {
        puzzleHint.gameObject.SetActive(true);
        gameObject.SetActive(true);
        roomCam.transform.position = new Vector3(250f, -100f, -100);
        eyeUI.gameObject.SetActive(false);
    }
}
