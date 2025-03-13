using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene01Events : MonoBehaviour
{

    public GameObject fadeScreenIn;
    public GameObject textBox;
    public GameObject fadeScreenOut;

    [SerializeField] string text;
    [SerializeField] int currentTextLength;
    [SerializeField] int textlength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] int eventPos = 0;

    void Update()
    {
        textlength = TextCreator.charCount;

        if (Input.GetMouseButtonDown(0) && textlength == currentTextLength && eventPos == 1)
        {
            StartCoroutine(EventOne());
        }
        if (Input.GetMouseButtonDown(0) && textlength == currentTextLength && eventPos == 2)
        {
            StartCoroutine(EventTwo());
        }
        if (Input.GetMouseButtonDown(0) && textlength == currentTextLength && eventPos == 3)
        {
            StartCoroutine(EventThree());
        }
    }

    void Start()
    {
        StartCoroutine(EventStarter());
        fadeScreenOut.SetActive(false);
    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(2);
        fadeScreenIn.SetActive(false);
        yield return new WaitForSeconds(2);
        // dialogue goes here...
        mainTextObject.SetActive(true);
        text = "I received an anonymous letter.";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = 1;

    }


    IEnumerator EventOne()
    {
        // event 1
        textBox.SetActive(true);
        text = "It was brief and enigmatic, urging me to visit a mysterious mansion said to be the site of a tragic event.";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        eventPos = 2;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator EventTwo()
    {
        // event 2
        textBox.SetActive(true);
        text = "As a journalist by profession, my curiosity drives me to visit the place mentioned in the letter, even if it proves to be a mere prank.";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        eventPos = 3;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator EventThree()
    {
        // event 3
        fadeScreenOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }




}
