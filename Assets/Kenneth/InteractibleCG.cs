using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractibleCG : MonoBehaviour
{
    public bool inRange;
    public UnityEvent interactAction;
    public GameObject interactionPrompt;
    public bool isInteracting;

    private void Start()
    {
        interactionPrompt.SetActive(false);
        isInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetMouseButtonDown(0))
        {
            interactAction.Invoke(); 
            Debug.Log("Interacting");
            isInteracting = true;
        } else
        {
            isInteracting = false;
        }
    }

    private void OnMouseEnter()
    {
        inRange = true;
        interactionPrompt.SetActive(true);
    }

    private void OnMouseExit()
    {
        inRange = false;
        interactionPrompt.SetActive(false);
    }
}
