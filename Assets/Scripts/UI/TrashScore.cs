using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashScore : MonoBehaviour
{
    public TMP_Text trashScore;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        trashScore.text = "Trash Score: " + GameStats.Instance.trashScore.ToString();
        // Debug.Log(trashScore.text);
        // Debug.Log(GameStats.Instance.trashScore);
    }
}