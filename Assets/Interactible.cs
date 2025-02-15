using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    public bool inRange;
    public UnityEvent interactAction;

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            interactAction.Invoke();
            Debug.Log("Player is moving on");
        } else if (!inRange && Input.GetKeyDown(KeyCode.E)) 
        { 
            Debug.Log("You're not doing anything");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("You can open the door");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log("You can't open the door");
        }
    }
}
