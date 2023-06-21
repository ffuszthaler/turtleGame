using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurtleStats : MonoBehaviour
{
    [field: SerializeField] public float turtleHealth { private set; get; }

    public void ReduceHealth(float amount)
    {
        turtleHealth -= amount;

        if (turtleHealth == 0f)
        {
            Destroy(transform.parent.gameObject);
        }

        Debug.Log("Enemy Health: " + turtleHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if (_turtles.Length == 0)
        // {
        //     SceneManager.LoadSceneAsync("GameOver");
        // }
    }
}