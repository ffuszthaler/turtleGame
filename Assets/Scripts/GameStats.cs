using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    // [SerializeField] private float trashScore = 0f;
    [field: SerializeField] public float trashScore { private set; get; }

    public void IncreaseTrashScore(float value)
    {
        trashScore += value;
        Debug.Log("Trash Score: " + trashScore);
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