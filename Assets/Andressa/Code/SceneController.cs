using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void NextLevel()
    {
        SceneManagement.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
