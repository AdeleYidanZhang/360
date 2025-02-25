using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDirector : MonoBehaviour
{

    public ItemValuePuzzle box1;
    public ItemValuePuzzle box2;
    public ItemValuePuzzle box3;
    public ItemValuePuzzle box4;
    public ItemValuePuzzle box5;

    public Canvas puzzleScreen;
    public GameObject PraiseText;

    public bool exitUnlocked;

    // Update is called once per frame
    void Update()
    {
        if (box1.correctMatch && box2.correctMatch && box3.correctMatch && box4.correctMatch && box5.correctMatch)
        {
            exitUnlocked = true;
        } else
        {
            exitUnlocked = false;
        }


        PraiseText.SetActive(exitUnlocked);
    }

    public void CloseScreen()
    {
        puzzleScreen.enabled = false;
    }
}
