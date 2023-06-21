using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    [field: SerializeField] public float trashScore { private set; get; }
    [field: SerializeField] public float turtleScore { private set; get; }

    public void IncreaseTrashScore(float value)
    {
        trashScore += value;
        Debug.Log("Trash Score: " + trashScore);

        if (trashScore == 3f)
        {
            SceneManager.LoadSceneAsync("GameOver");
        }
    }

    public void IncreaseTurtleScore(float value)
    {
        turtleScore += value;
        Debug.Log("Turtle Score: " + trashScore);

        // TODO: this is temporary
        if (turtleScore == 5f)
        {
            SceneManager.LoadSceneAsync("GameWin");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}