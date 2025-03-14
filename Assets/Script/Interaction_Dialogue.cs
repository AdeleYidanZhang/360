using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interaction_Dialogue : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    //public GameObject contButton;

    public float wordSpeed;
    public bool playerIsClose;

    private bool isTyping;

    private void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                if (isTyping) 
                {

                    StopAllCoroutines();
                    dialogueText.text = dialogue[index];
                    isTyping = false;
                }
                else
                {
                    NextLine(); 
                }
            }
            else
            {

                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        //if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        //{

        //    if (dialoguePanel.activeInHierarchy)
        //    {
        //        zeroText();
        //    }
        //    else
        //    {
        //        dialoguePanel.SetActive(true);
        //        StartCoroutine(Typing());
        //    }


        //}

        //if (dialogueText.text == dialogue[index])
        //{
        //    contButton.SetActive(true);
        //}

    }


    public void zeroText()//reset dialogue;
    {

        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        isTyping = false;

    }

    IEnumerator Typing()
    {

        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        isTyping = false;

    }

    public void NextLine()
    {

        //contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            //dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }

}
