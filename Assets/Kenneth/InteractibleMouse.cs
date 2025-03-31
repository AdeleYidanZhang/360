using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractibleMouse : MonoBehaviour
{
    public bool inRange;
    public UnityEvent interactAction;
    public GameObject interactionPrompt;

    private void Start()
    {
        interactionPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetMouseButtonUp(0)) // left click
        {
            interactAction.Invoke(); 
            Debug.Log("Interacting");
        }
    }

    private void OnMouseOver()
    {
        inRange = true;
    }

    private void OnMouseExit()
    {
        inRange = false;
    }
}
