using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinController : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync("Level01");
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}