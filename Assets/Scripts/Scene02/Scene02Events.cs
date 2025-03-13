using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene02Events : MonoBehaviour
{

    [SerializeField] GameObject fadeScreenIn2;
    [SerializeField] GameObject fadeScreenOut2;
    public GameObject textBox;
    [SerializeField] string text;
    [SerializeField] int currentTextLength;
    [SerializeField] int textlength;
    [SerializeField] GameObject mainTextObject;

    void Start()
    {
        StartCoroutine(EventStarter());
        fadeScreenOut2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textlength = TextCreator.charCount;
    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(2);
        fadeScreenIn2.SetActive(false);
        yield return new WaitForSeconds(2);
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
    }
}
