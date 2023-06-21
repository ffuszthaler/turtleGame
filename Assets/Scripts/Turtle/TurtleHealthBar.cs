using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleHealthBar : MonoBehaviour
{
    [SerializeField] public TurtleStats turtleStats;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = turtleStats.turtleHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(turtleStats.turtleHealth / maxHealth, 1, 1);
    }
}