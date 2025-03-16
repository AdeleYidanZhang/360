using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEndController : MonoBehaviour
{
    public GameObject DemoEndUnlocked;
    public GameObject DemoEndLocked;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("demoDoorLock") == 1) // 1 is locked
        {
            DemoEndUnlocked.SetActive(false);
            DemoEndLocked.SetActive(true);
        }
        if (PlayerPrefs.GetInt("demoDoorLock") == 0)
        {
            DemoEndUnlocked.SetActive(true);
            DemoEndLocked.SetActive(false);
        }
    }
}
