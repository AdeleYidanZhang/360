using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    public bool inRange;
    public UnityEvent interactAction;
    public GameObject interactionPrompt;
    public bool isInteracting;
    public ShaderManipulation outline;

    private void Start()
    {
        interactionPrompt.SetActive(false);
        isInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            interactAction.Invoke(); 
            Debug.Log("Interacting");
            isInteracting = true;
        } else
        {
            isInteracting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            interactionPrompt.SetActive(true);
            outline.isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            interactionPrompt.SetActive(false);
            outline.isInRange = false;
        }
    }
}
