using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClosetController : MonoBehaviour
{
    public Actor door;

    public Dialogue lockedScenario;
    public Dialogue unlockedScenario;

    private void Update()
    {
        if (PlayerPrefs.GetInt("closetDoorLock") == 1) // 1 is locked
        {
            door.Dialogue = lockedScenario;
        }

        if (PlayerPrefs.GetInt("closetDoorLock") == 0)
        {
            door.Dialogue = unlockedScenario;
        }
    }

    public void ClosetDoor()
    {
        PlayerPrefs.SetInt("demoDoorLock", 1);
    }
}
