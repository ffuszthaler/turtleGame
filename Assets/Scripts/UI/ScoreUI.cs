using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            score.text = "Trash Collected: " + GameStats.Instance.trashScore.ToString();
        }
        else if (SceneManager.GetActiveScene().name == "Level02")
        {
            score.text = "Turtles Saved: " + GameStats.Instance.turtleScore.ToString();
        }
    }
}