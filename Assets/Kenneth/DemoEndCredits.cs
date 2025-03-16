using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DemoEndCredits : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    //public GameObject contButton;

    public float wordSpeed;
    public bool playerIsClose;
    public Canvas UI;
    public GameObject prompt;

    private bool isTyping;

    private void Start()
    {
        prompt.SetActive(false);
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            UI.gameObject.SetActive(false);

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
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            prompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            prompt.SetActive(false);
        }
    }

}
