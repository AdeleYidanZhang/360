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
    public float angleOffset;


    private void Start()
    {
        notWonYet = true;
        rightClickActive = false;
    }

    void Update()
    {

        //This fires only on the frame the button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            rightClickActive = true;
            screenPos = myCam.WorldToScreenPoint(transform.position);
            Vector3 vec3 = Input.mousePosition - screenPos;
            angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
        }
        if (Input.GetMouseButtonUp(1))
        {
            rightClickActive = false;
        }

        //This fires while the button is pressed down
        if (Input.GetMouseButton(1) && notWonYet)
        {
            Vector3 vec3 = Input.mousePosition - screenPos;
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);

        }
    }
}
