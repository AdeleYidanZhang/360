using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene02Events : MonoBehaviour
{

    [SerializeField] GameObject fadeScreenIn2;
    [SerializeField] GameObject fadeScreenOut2;
    [SerializeField] GameObject textBox;
    [SerializeField] string text;
    [SerializeField] int currentTextLength;
    [SerializeField] int textlength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] int eventPos = 0;
    [SerializeField] Button yesButton;
    [SerializeField] Button yesAfterButton;
    [SerializeField] Button noButton;
    [SerializeField] GameObject gateInteract;
    [SerializeField] GameObject gateInteract2;
    [SerializeField] GameObject mansionInteract;
    [SerializeField] GameObject skyInteract;
    [SerializeField] GameObject afarInteract;
    [SerializeField] bool gateChecked = false;
    [SerializeField] bool skyChecked = false;
    [SerializeField] bool afarChecked = false;
    [SerializeField] bool mansionChecked = false;

    void Start()
    {
        StartCoroutine(EventStarter());
        fadeScreenOut2.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        gateInteract.SetActive(false);
        gateInteract2.SetActive(false);
        skyInteract.SetActive(false);
        mansionInteract.SetActive(false);
        afarInteract.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textlength = TextCreator.charCount;

        if (Input.GetMouseButtonDown(0) && textlength == currentTextLength && eventPos == 1)
        {
            StopCoroutine(EventStarter());
            StartCoroutine(EventOne());
        }
        if (Input.GetMouseButtonDown(0) && textlength == currentTextLength && eventPos == 2)
        {
            StopCoroutine (EventOne());
            StartCoroutine(EventTwo());
        }
        if (Input.GetMouseButtonDown(0) && textlength == currentTextLength && eventPos == 3)
        {
            StopCoroutine(EventTwo());
            StartCoroutine(EventThree());
        }
        if (Input.GetMouseButtonDown(0) && textlength == currentTextLength && eventPos == 4)
        {
            StopCoroutine(EventThree());
            StartCoroutine(EventFour());
        }

    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(2);
        fadeScreenIn2.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        // dialogue goes here...
        mainTextObject.SetActive(true);
        text = "This seems to be the place...";
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
        text = "The wind lends an eerie chill to the mansion, as if whispering secrets of the past. What exactly happened here?";
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
        text = "Should I step inside and take a look?";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        eventPos = 0;
        yield return new WaitForSeconds(1.5f);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
               // if yes, transition into the next scene
               // if false, setActive interactive objects

    }


    IEnumerator EventThree()
    {
        //after clicking the NoButton:
        StopAllCoroutines();
        mainTextObject.SetActive(false);
        eventPos = 0;
        yield return new WaitForSeconds(0.05f);
        mainTextObject.SetActive(false);
    }

    IEnumerator EventFour()
    {
        // event 4
        fadeScreenOut2.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Hallway"); // switch to the hallway
    }

    public void ClickYesButton()
    {   
        StartCoroutine(YesButtonInteract());

    }

    public void ClickNoButton()
    {
        StartCoroutine (NoButtonInteract());
    }

    public void ClickOnGate()
    {
        if (textlength == currentTextLength)
        {   
            StopAllCoroutines();
            StartCoroutine(GateInteract());
            gateChecked = true;
        }
        
    }

    public void ClickOnMansion()
    {
        if (textlength == currentTextLength)
        {
            StopAllCoroutines();
            StartCoroutine(MansionInteract());
            mansionChecked = true;
        }
    }

    public void ClickOnSky()
    {
        if (textlength == currentTextLength)
        {
            StopAllCoroutines();
            StartCoroutine(SkyInteract());
            skyChecked = true;
        }

    }

    public void ClickOnAfar()
    {
        if (textlength == currentTextLength)
        {
            StopAllCoroutines();
            StartCoroutine(AfarInteract());
            afarChecked = true;

        }
    }

    IEnumerator YesButtonInteract()
    {   
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        gateInteract.SetActive(false);
        gateInteract2.SetActive(false);
        skyInteract.SetActive(false);
        mansionInteract.SetActive(false);
        afarInteract.SetActive(false);
        yesAfterButton.gameObject.SetActive(false);
        mainTextObject.SetActive(true);
        text = "This mansion seems to carry an inexplicable sense of malevolence, casting a spell on me, compelling me to step deeper in search of something unknown, as if I am sinking into a swamp, unable to escape...";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = 4;
        
    }

    IEnumerator NoButtonInteract()
    {
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        text = "I should take a look around for any clues first.";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        gateInteract.SetActive(true);
        gateInteract2.SetActive(true);
        skyInteract.SetActive(true);
        mansionInteract.SetActive(true);
        afarInteract.SetActive(true);
        yesAfterButton.gameObject.SetActive(true);
        eventPos = 3;
    }

    IEnumerator GateInteract()
    {
        mainTextObject.SetActive(true);
        text = "The gate is opened. Someone has been here before?";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = 3;
    }

    IEnumerator MansionInteract()
    {

        if (mansionChecked && skyChecked && afarChecked && gateChecked)
        {
            mainTextObject.SetActive(true);
            text = "This mansion seems to carry an inexplicable sense of malevolence, casting a spell on me, compelling me to step deeper in search of something unknown, as if I am sinking into a swamp, unable to escape...";
            textBox.GetComponent<TMPro.TMP_Text>().text = text;
            currentTextLength = text.Length;
            TextCreator.runTextPrint = true;
            yield return new WaitForSeconds(0.05f);
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => textlength == currentTextLength);
            yield return new WaitForSeconds(0.5f);
            eventPos = 4;
        }
        else
        {
            mainTextObject.SetActive(true);
            text = "This mansion...I am feeling an indescribable sense of familiarity with this mansion. However, no matter how hard I try to recall, all that remains in my mind is a pounding headache and ringing in my ears.";
            textBox.GetComponent<TMPro.TMP_Text>().text = text;
            currentTextLength = text.Length;
            TextCreator.runTextPrint = true;
            yield return new WaitForSeconds(0.05f);
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => textlength == currentTextLength);
            yield return new WaitForSeconds(0.5f);
            eventPos = 3;
        }

    }

    IEnumerator SkyInteract()
    {

        mainTextObject.SetActive(true);
        text = "The weather has been cloudy lately. Looks like it is going to rain soon.";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = 3;
    }

    IEnumerator AfarInteract()
    {
        mainTextObject.SetActive(true);
        text = "The surrounding area is nothing but desolate mountains and wilderness. Apart from this mansion, there seems to be no sign of any other buildings.";
        textBox.GetComponent<TMPro.TMP_Text>().text = text;
        currentTextLength = text.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textlength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = 3;
    }


}
