using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeStart : MonoBehaviour
{
    private float _radius = 5f;

    public GameObject target;
    public GameObject turtle;

    private GameObject newTurtle;

    public void randomizePositionAfterTurtle()
    {
        // why??? 1 not 0
        if (GameObject.FindGameObjectsWithTag("Turtle").Length == 1)
        {
            Debug.Log("dsfgdfgdfgdg");
            newTurtle = Instantiate(turtle, transform.position, transform.rotation);
        }

        Debug.Log("same");

        Vector3 randomSpawnPoint = Random.insideUnitSphere * _radius;
        randomSpawnPoint.y = 0.5f;

        transform.position = randomSpawnPoint;
        newTurtle.transform.position = randomSpawnPoint;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Turtle").Length);

        if (turtle)
        {
            if (turtle.transform.position == target.transform.position)
            {
                // maybe add logic to also delete newTurtle after it is being used instead of original turtle
                Destroy(turtle);

                Debug.Log("after destroy: " + GameObject.FindGameObjectsWithTag("Turtle").Length);
                randomizePositionAfterTurtle();
            }
        }
    }
}