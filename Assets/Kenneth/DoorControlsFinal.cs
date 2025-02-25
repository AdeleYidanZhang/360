using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControlsFinal : MonoBehaviour
{
    public Interactible DoorEntrance;
    public Interactible DoorExit;

    public SceneDirector director;
    public MasterInstance mainProcess;
    public PuzzleDirector puzzleMaster;
    public string sceneName;
    public TopDownPlayerMovement roomPlayer;

    public Canvas puzzle;
    public Canvas ending;
    public Canvas eyes;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        mainProcess = (MasterInstance)FindAnyObjectByType(typeof(MasterInstance));
        MasterInstance.loadPersistentLevel();
        roomPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("RoomPlayerX"), PlayerPrefs.GetFloat("RoomPlayerY"), PlayerPrefs.GetFloat("RoomPlayerZ"));

        puzzle.enabled = false;
        ending.enabled = false;
    }

    private void Update()
    {
        DoorExit.enabled = puzzleMaster.exitUnlocked;
        //director.positionSaving.Add(sceneName, transform.position);

        PlayerPrefs.SetFloat("RoomPlayerX", roomPlayer.transform.position.x);
        PlayerPrefs.SetFloat("RoomPlayerY", roomPlayer.transform.position.y);
        PlayerPrefs.SetFloat("RoomPlayerZ", roomPlayer.transform.position.z);

        if (puzzle.isActiveAndEnabled || ending.isActiveAndEnabled)
        {
            eyes.enabled = false;
        } else
        {
            eyes.enabled = true;
        }
    }

    public void FromRoomToHall()
    {
        director.EnterHallway();
        //player.transform.position = director.positionSaving["Hallway"];
    }

    public void PuzzleUnlock()
    {
        puzzle.enabled = true;
    }

    public void EndGame()
    {
        if (puzzleMaster.exitUnlocked)
        {
            ending.enabled = true;
        }
        else
        {
            Debug.Log("Door is locked!");
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
