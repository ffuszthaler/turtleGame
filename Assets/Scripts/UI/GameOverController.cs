using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverScreen;


    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

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