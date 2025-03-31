using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfPuzzleForCode : MonoBehaviour
{
    public ItemValuePuzzle shelf1;
    public ItemValuePuzzle shelf2;
    public ItemValuePuzzle shelf3;
    public ItemValuePuzzle shelf4;
    public ItemValuePuzzle shelf5;

    public BookshelfPuzzle otherSelf;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shelf1.correctMatch && shelf2.correctMatch && shelf3.correctMatch && shelf4.correctMatch && shelf5.correctMatch)
        {
            otherSelf.foundBookOrderYet = true;
        }
    }
}
