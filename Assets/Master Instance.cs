using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterInstance : MonoBehaviour
{

    public CentralProcessing CPU;
    public Animator transitionAnimator;

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
    }

    #endregion Instance Manager

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Opening")
        {
            Instantiate(CPU.PlayerPawns.PlayerHall);
        }

        if (SceneManager.GetActiveScene().name == "Hallway")
        {
            Instantiate(CPU.PlayerPawns.PlayerHall);
            CPU.VisualPawns.Direction1();
        }

        if (SceneManager.GetActiveScene().name == "Room")
        {
            Instantiate(CPU.PlayerPawns.PlayerChibi);
            CPU.VisualPawns.ChibiHall();
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Opening")
        {
            CPU.VisualPawns.MainMenu();
            transitionAnimator.SetTrigger("End");
        }

        if (SceneManager.GetActiveScene().name == "Hallway")
        {
            CPU.VisualPawns.Direction1();
            transitionAnimator.SetTrigger("End");
        }

        if (SceneManager.GetActiveScene().name == "Room")
        {
            CPU.VisualPawns.ChibiHall();
            transitionAnimator.SetTrigger("End");
        }

    }
}
