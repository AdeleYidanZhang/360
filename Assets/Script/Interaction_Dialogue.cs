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
    private Coroutine typingCoroutine; // 保存当前正在运行的协程

    private float timeSinceLastPress = 0f;
    public float pressCooldown = 0.4f; // 0.2秒冷却时间


    private void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastPress += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && timeSinceLastPress >= pressCooldown)
        {
            timeSinceLastPress = 0f; // 重置计时器
            if (dialoguePanel.activeInHierarchy)
            {
                if (isTyping) 
                {

                    StopTyping(); // 停止当前打字的协程
                    //StopAllCoroutines();
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
                //StartCoroutine(Typing());
                StartTyping(); // 启动打字协程

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

    // 启动打字协程
    private void StartTyping()
    {
        StopTyping(); // 确保之前的打字协程被停止
        typingCoroutine = StartCoroutine(Typing()); // 开始新的打字协程
    }

    // 停止当前的打字协程
    private void StopTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // 停止旧的打字协程
            typingCoroutine = null;
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
            //StartCoroutine(Typing());
            StartTyping(); // 显示下一行对话
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
            // 在调用 zeroText() 之前，检查 dialoguePanel 是否为 null
            if (dialoguePanel != null)
            {
                zeroText();
            }
        }
    }

}
