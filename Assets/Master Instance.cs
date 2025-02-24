using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterInstance : MonoBehaviour
{
    public CentralProcessing CPU;
    public Animator transitionAnimator;
    private Scene currentSet;

    public HallwayPlayerMovement hallPlayerClone;
    public TopDownPlayerMovement roomPlayerClone;

    #region Instance Manager
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void loadPersistentLevel()
    {
        const string LevelName = "DevRoom";

        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; sceneIndex++)
        {
            if (SceneManager.GetSceneAt(sceneIndex).name == LevelName)
            {
                return;
            }
        }

        SceneManager.LoadScene(LevelName, LoadSceneMode.Additive);
    }

    public static MasterInstance Instance { get; private set; } = null;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"Found duplicate instance on {gameObject.name}");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        currentSet = SceneManager.GetActiveScene();
    }

    #endregion Instance Manager

    public void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;

        if (currentSet.name == "Hallway")
        {
            hallPlayerClone = Instantiate(CPU.PlayerPawns.PlayerHall);
            CPU.VisualPawns.Direction1();
        }

        if (currentSet.name == "Room")
        {
            roomPlayerClone = Instantiate(CPU.PlayerPawns.PlayerChibi);
            CPU.VisualPawns.ChibiHall();
        }
    }

    void Update()
    {
        if (currentSet.name == "FlipsideOpening")
        {
            CPU.VisualPawns.MainMenu();
            transitionAnimator.SetTrigger("End");
        }

        if (currentSet.name == "Hallway")
        {
            CPU.VisualPawns.Direction1();
            transitionAnimator.SetTrigger("End");
        }

        if (currentSet.name == "Room")
        {
            CPU.VisualPawns.ChibiHall();
            transitionAnimator.SetTrigger("End");
        }

    }

    // Listener for sceneLoaded
    private void ChangedActiveScene(Scene current, Scene next)
    {
        Debug.Log("Scenes: " + current.name + ", " + next.name);
        if (next.name == "FlipsideOpening")
        {
            CPU.VisualPawns.MainMenu();
        }

        if (next.name == "Hallway")
        {
            hallPlayerClone = Instantiate(CPU.PlayerPawns.PlayerHall);
            CPU.VisualPawns.Direction1();
        }

        if (next.name == "Room")
        {
            roomPlayerClone = Instantiate(CPU.PlayerPawns.PlayerChibi);
            CPU.VisualPawns.ChibiHall();
        }
    }
}
