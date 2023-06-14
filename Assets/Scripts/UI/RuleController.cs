using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleController : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync("Level01");
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}