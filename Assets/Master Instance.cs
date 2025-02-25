using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MasterInstance : MonoBehaviour
{
    public Animator transitionAnimator;
    private Scene currentSet;

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

        transitionAnimator = (Animator)FindObjectOfType(typeof(Animator));

        Instance = this;
        currentSet = SceneManager.GetActiveScene();
        DontDestroyOnLoad(Instance);
    }

    #endregion Instance Manager

    public void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        currentSet = SceneManager.GetActiveScene();
    }

    void Update()
    {
        currentSet = SceneManager.GetActiveScene();
        transitionAnimator.SetTrigger("End");

        
    }

    // Listener for sceneLoaded
    private void ChangedActiveScene(Scene current, Scene next)
    {
        Debug.Log("Scenes: " + current.name + ", " + next.name);
        
    }
}