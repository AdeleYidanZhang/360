using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterInstance : MonoBehaviour
{
    public CentralProcessing CPU;
    public Animator transitionAnimator;
    public Canvas UIScreen;
    private Scene currentSet;

    public Vector3 lastPositionHallway;
    public Vector3 lastPositionRoom;

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
        currentSet = SceneManager.GetActiveScene();
        DontDestroyOnLoad(Instance);
    }

    #endregion Instance Manager

    public void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        currentSet = SceneManager.GetActiveScene();

        if (currentSet.name == "Hallway")
        {
            CPU.hallwaySetting();
        }

        if (currentSet.name == "Room")
        {
            CPU.roomSetting();
        }
    }

    void Update()
    {
        currentSet = SceneManager.GetActiveScene();

        if (currentSet.name == "FlipsideOpening")
        {
            CPU.VisualPawns.MainMenu();
        }

        if (currentSet.name == "Hallway")
        {
            CPU.hallwaySetting();
        }

        if (currentSet.name == "Room")
        {
            CPU.roomSetting();
        }
        transitionAnimator.SetTrigger("End");
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
            CPU.hallwaySetting();
        }

        if (next.name == "Room")
        {
            CPU.roomSetting();
        }
    }
}