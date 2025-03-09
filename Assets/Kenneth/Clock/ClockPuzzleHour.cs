using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzleHour : MonoBehaviour
{
    [SerializeField]

    public Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D hourHandCol;
    public bool notWonYet;
    public bool rightClickActive;

    private void Start()
    {
        hourHandCol = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector3 mousePos = myCam.ViewportToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (Input.GetMouseButtonDown(1) && notWonYet) // right click
        {
            if (hourHandCol == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = myCam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;

                rightClickActive = true;
            }
        }
        if (Input.GetMouseButton(1) && notWonYet)
        {
            if (hourHandCol == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);

                rightClickActive = true;
            }
        }
        else
        {
            rightClickActive = false;
        }
    }
}
