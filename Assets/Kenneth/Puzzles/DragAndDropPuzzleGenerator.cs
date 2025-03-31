using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropPuzzleGenerator : MonoBehaviour
{
    public Canvas bookshelf;
    public Canvas UI;
    public Camera roomCam;

    // Start is called before the first frame update
    void Start()
    {
        bookshelf.gameObject.SetActive(false);
    }

   
    public void OpenPuzzle()
    {
        UI.gameObject.SetActive(false);
        roomCam.transform.position = new Vector3(0f, -300f, -20f);
        bookshelf.gameObject.SetActive(true);
    }

    public void ClosePuzzle()
    {
        UI.gameObject.SetActive(true);
        roomCam.transform.position = new Vector3(0f, -400f, -60f);
        bookshelf.gameObject.SetActive(false);
    }
}
