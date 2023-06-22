using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    [field: SerializeField] public float trashScore { private set; get; }
    private float _maxTrashCount = 10f;
    [field: SerializeField] public float turtleScore { private set; get; }
    private float _maxTurtleCount = 5f;

    public void IncreaseTrashScore(float value)
    {
        trashScore += value;
        Debug.Log("Trash Score: " + trashScore);

        if (trashScore == _maxTrashCount)
        {
            SceneManager.LoadSceneAsync("Level02");
        }
    }

    public void IncreaseTurtleScore(float value)
    {
        turtleScore += value;
        Debug.Log("Turtle Score: " + trashScore);

        if (turtleScore == _maxTurtleCount)
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