using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    [field: SerializeField] public float trashScore { private set; get; }

    // TODO: maybe move this to its own file
    public void IncreaseTrashScore(float value)
    {
        trashScore += value;
        Debug.Log("Trash Score: " + trashScore);

        // TODO: this is temporary
        if (trashScore == 3f)
        {
            SceneManager.LoadSceneAsync("Level02");
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