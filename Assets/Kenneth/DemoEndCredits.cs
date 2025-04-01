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
    private bool isTyping;

    private void Start()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
}
