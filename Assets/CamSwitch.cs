using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CamSwitch : MonoBehaviour
{
    public TMP_Text direction;
    public TMP_Text number;
    public GameObject cameraNever;
    public GameObject cameraEat;
    public GameObject cameraShreded;
    public GameObject camereaWheat;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("NorthCamera")) // North
        {
            direction.text = "Camera Direction — North";
            number.text = "Camera Number — 1";
            cameraNever.SetActive(true);
            cameraEat.SetActive(false);
            cameraShreded.SetActive(false);
            camereaWheat.SetActive(false);
        }

        if (Input.GetButtonDown("EastCamera")) // East
        {
            direction.text = "Camera Direction — East";
            number.text = "Camera Number — 2";
            cameraNever.SetActive(false);
            cameraEat.SetActive(true);
            cameraShreded.SetActive(false);
            camereaWheat.SetActive(false);
        }
         
        if (Input.GetButtonDown("SouthCamera")) // South
        {
            direction.text = "Camera Direction — South";
            number.text = "Camera Number — 3";
            cameraNever.SetActive(false);
            cameraEat.SetActive(false);
            cameraShreded.SetActive(true);
            camereaWheat.SetActive(false);
        }

        if (Input.GetButtonDown("WestCamera")) // West
        {
            direction.text = "Camera Direction — West";
            number.text = "Camera Number — 4";
            cameraNever.SetActive(false);
            cameraEat.SetActive(false);
            cameraShreded.SetActive(false);
            camereaWheat.SetActive(true);
        }
    }
}
