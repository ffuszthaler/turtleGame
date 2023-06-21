using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScoreUI : MonoBehaviour
{
    public TMP_Text endScoreSentence;

    // Start is called before the first frame update
    void Start()
    {
        endScoreSentence.text = "You collected " + GameStats.Instance.trashScore.ToString() + " trash and saved " +
                                GameStats.Instance.turtleScore.ToString() + " turtles.";
    }

    // Update is called once per frame
    void Update()
    {
    }
}