using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    // Start is called before the first frame update
    void Start()
    {
        player1.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player3.GetComponent<PlayerMovement>().enabled = false;
        player4.GetComponent<PlayerMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("NorthCamera")) // wall1
        {
            player1.GetComponent<PlayerMovement>().enabled = true;
            player2.GetComponent<PlayerMovement>().enabled = false;
            player3.GetComponent<PlayerMovement>().enabled = false;
            player4.GetComponent<PlayerMovement>().enabled = false;
        }

        if (Input.GetButtonDown("SouthCamera")) // wall3
        {
            player1.GetComponent<PlayerMovement>().enabled = false;
            player2.GetComponent<PlayerMovement>().enabled = false;
            player3.GetComponent<PlayerMovement>().enabled = true;
            player4.GetComponent<PlayerMovement>().enabled = false;
        }

        if (Input.GetButtonDown("WestCamera")) // wall2
        {
            player1.GetComponent<PlayerMovement>().enabled = false;
            player2.GetComponent<PlayerMovement>().enabled = false;
            player3.GetComponent<PlayerMovement>().enabled = false;
            player4.GetComponent<PlayerMovement>().enabled = true;
        }

        if (Input.GetButtonDown("EastCamera")) // wall4
        {
            player1.GetComponent<PlayerMovement>().enabled = false;
            player2.GetComponent<PlayerMovement>().enabled = true;
            player3.GetComponent<PlayerMovement>().enabled = false;
            player4.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
