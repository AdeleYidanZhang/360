using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BookshelfPuzzle : MonoBehaviour
{

    public static string inputCode = "37194";
    public static string playerInput = "";

    public bool foundBookOrderYet;
    public bool puzzleSolved;

    public GameObject filter;
    public GameObject WinAnnouncement;
    public TextMeshProUGUI PlayerProgress;

    public Camera roomCam;
    public Canvas eyeUI;
    public Canvas backOffButton;

    // Start is called before the first frame update
    void Start()
    {
        foundBookOrderYet = false;
        backOffButton.gameObject.SetActive(false);
        puzzleSolved = false;
        WinAnnouncement.SetActive(false);
        exitBookSelf();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerProgress.text = playerInput;

        if (!foundBookOrderYet)
        {
            filter.SetActive(true);
            PlayerProgress.gameObject.SetActive(false);
        }
        if (foundBookOrderYet)
        {
            filter.SetActive(false);
            PlayerProgress.gameObject.SetActive(true);
        }

        // win condition
        if (playerInput.Length == 5)
        {
            if (playerInput == inputCode)
            {
                puzzleSolved = true;
                WinAnnouncement.SetActive(true);
            } else
            {
                playerInput = "";
            }
        }
    }

    public void ClickedOnFilter()
    {
        playerInput += "0";
    }

    public void ClickedOnBook1()
    {
        playerInput += "3";
    }

    public void ClickedOnBook2()
    {
        playerInput += "7";
    }

    public void ClickedOnBook3()
    {
        playerInput += "1";
    }

    public void ClickedOnBook4()
    {
        playerInput += "9";
    }

    public void ClickedOnBook5()
    {
        playerInput += "4";
    }

    public void ClickedOnFillerBook()
    {
        playerInput += "0";
    }

    public void enterBookShelf()
    {
        backOffButton.gameObject.SetActive(true);
        eyeUI.gameObject.SetActive(false);
        roomCam.transform.position = new Vector3(250f, -400f, -20f);
    }

    public void exitBookSelf()
    {
        backOffButton.gameObject.SetActive(false);
        eyeUI.gameObject.SetActive(true);
        roomCam.transform.position = new Vector3(0f, -397f, -60f);
    }

    public void enterSortingShelf()
    {
        backOffButton.gameObject.SetActive(true);
        eyeUI.gameObject.SetActive(false);
        roomCam.transform.position = new Vector3(0f, -200f, -20f);
    }
}
