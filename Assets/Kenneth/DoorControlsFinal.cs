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
    public TopDownPlayerMovement player;

    public Canvas puzzle;
    public Canvas ending;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        director.positionSaving.Add(sceneName, DoorEntrance.transform.position);
    }

    void Start()
    {
        mainProcess = (MasterInstance)FindAnyObjectByType(typeof(MasterInstance));
        MasterInstance.loadPersistentLevel();
        player.transform.position = mainProcess.lastPositionRoom;

        puzzle.enabled = false;
        ending.enabled = false;
    }

    private void Update()
    {
        DoorExit.enabled = puzzleMaster.exitUnlocked;
        //director.positionSaving.Add(sceneName, transform.position);
        mainProcess.lastPositionRoom = player.transform.position;

        if (puzzle.isActiveAndEnabled || ending.isActiveAndEnabled)
        {
            mainProcess.UIScreen.enabled = false;
        } else
        {
            mainProcess.UIScreen.enabled = true;
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
}
