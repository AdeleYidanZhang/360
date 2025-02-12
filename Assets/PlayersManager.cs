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
        Hallway1();
    }

    public void Hallway1()
    {
        player1.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player3.GetComponent<PlayerMovement>().enabled = false;
        player4.GetComponent<PlayerMovement>().enabled = false;
    }

    public void Hallway2()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = true;
        player3.GetComponent<PlayerMovement>().enabled = false;
        player4.GetComponent<PlayerMovement>().enabled = false;
    }

    public void Hallway3()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player3.GetComponent<PlayerMovement>().enabled = true;
        player4.GetComponent<PlayerMovement>().enabled = false;
    }

    public void Hallway4()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player3.GetComponent<PlayerMovement>().enabled = false;
        player4.GetComponent<PlayerMovement>().enabled = true;
    }
}
