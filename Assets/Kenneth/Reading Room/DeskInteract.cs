using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInteract : MonoBehaviour
{
    public Canvas puzzleHint;
    public Canvas eyeUI;
    public Camera roomCam;

    // Start is called before the first frame update
    void Start()
    {
        puzzleHint.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PeakAtTable()
    {
        puzzleHint.gameObject.SetActive(true);
        eyeUI.gameObject.SetActive(false);
        roomCam.transform.position = new Vector3(100f, -400f, -10f);
    }

    public void BackAwayFromTable()
    {
        puzzleHint.gameObject.SetActive(false);
        eyeUI.gameObject.SetActive(true);
        roomCam.transform.position = new Vector3(0f, -400f, -60f);
    }
}
