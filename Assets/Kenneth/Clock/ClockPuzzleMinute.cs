using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzleMinute : MonoBehaviour
{
    [SerializeField]

    public Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D minuteHandCol;
    public bool notWonYet;
    public bool leftClickActive;

    private void Start()
    {
        minuteHandCol = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector3 mousePos = myCam.ViewportToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (Input.GetMouseButtonDown(0) && notWonYet) // left click
        {
            if (minuteHandCol == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = myCam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;

                leftClickActive = true;
            }
        }
        if (Input.GetMouseButton(0) && notWonYet)
        {
            if (minuteHandCol == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                leftClickActive = true;
            }
        }

        else
        {
            leftClickActive = false;
        }
    }
}
