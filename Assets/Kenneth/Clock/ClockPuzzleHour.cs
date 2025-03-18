using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzleHour : MonoBehaviour // right click
{
    [SerializeField]

    public Camera myCam;
    private Vector3 screenPos;
    public bool notWonYet;
    public bool rightClickActive;
    public float angle;


    private void Start()
    {
        notWonYet = true;
        myCam = GetComponent<Camera>();
        rightClickActive = false;
    }

    void Update()
    {
        //This fires only on the frame the button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            rightClickActive = true;
            screenPos = myCam.ViewportToScreenPoint(transform.position);
            Vector3 v3 = Input.mousePosition - screenPos;
        }
        if (Input.GetMouseButtonUp(1))
        {
            rightClickActive = false;
        }

        //This fires while the button is pressed down
        if (Input.GetMouseButton(1) && notWonYet)
        {
            Vector3 v3 = Input.mousePosition - screenPos;
            angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
