using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class ClosetController : MonoBehaviour
{
    public string[] closedDialogue = {"Locked. Damnit", "What's this note?", "\"Time is the keeper of all things\"", "Noted..."};
    public string[] openedDialogue = {"Ah. Got it", "Keyring here with... one key. Better than nothing"};

    public Interaction_Dialogue talker;

    private void Update()
    {
        if (PlayerPrefs.GetInt("closetDoorLock") == 1) // 1 is locked
        {
            talker.dialogue = closedDialogue;
        }

        if (PlayerPrefs.GetInt("closetDoorLock") == 0)
        {
            talker.dialogue = openedDialogue;
            PlayerPrefs.SetInt("demoDoorLock", 0);
        }
    }
}
