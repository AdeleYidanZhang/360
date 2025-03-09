using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzleMaster : MonoBehaviour
{
    public ClockPuzzleMinute minuteHand;
    public ClockPuzzleHour hourHand;

    private float minuteHandPos;
    private float hourHandPos;

    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        minuteHand.notWonYet = true;
        hourHand.notWonYet = true;

    }

    // Update is called once per frame
    void Update() // NOTE: 12:00 IS 0. 9 IS 90. 6 IS 180. 3 IS -90
    {
        minuteHandPos = (Mathf.Round(minuteHand.transform.rotation.eulerAngles.z * 2) / 2);
        hourHandPos = (Mathf.Round(hourHand.transform.rotation.eulerAngles.z * 2) / 2);

        Debug.Log($"Minute Hand: {minuteHandPos}, Hour Hand: {hourHandPos}");

        if (minuteHandPos == 55f)
        {
            minuteHand.notWonYet = false;
        }

        if (hourHandPos == 221f)
        {
            hourHand.notWonYet = false;
        }

        if (!hourHand.notWonYet && !minuteHand.notWonYet)
        {
            winText.SetActive(true);
        }
    }
}
