using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropPuzzleGenerator : MonoBehaviour
{
    public Canvas bookshelf;

    // Start is called before the first frame update
    void Start()
    {
        bookshelf.gameObject.SetActive(false);
    }

   
    public void OpenPuzzle()
    {

        bookshelf.gameObject.SetActive(true);
    }

    public void ClosePuzzle()
    {

        bookshelf.gameObject.SetActive(false);
    }
}
