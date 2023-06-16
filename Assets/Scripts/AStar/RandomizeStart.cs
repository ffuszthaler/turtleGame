using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// this probably needs to be renamed
public class RandomizeStart : MonoBehaviour
{
    // make this smaller to limit spawn area of new turtles/seeker
    private readonly float _radiusX = 5f;
    private readonly float _radiusZ = 15f;

    public GameObject target;
    public GameObject turtlePrefab;
    public GameObject newTurtleInstance;

    private void RandomizePositionAfterTurtle()
    {
        if (GameObject.FindGameObjectsWithTag("Turtle").Length == 0)
        {
            newTurtleInstance = Instantiate(turtlePrefab, transform.position, transform.rotation);
        }

        Debug.Log("same");

        Vector3 randomSpawnPoint = Random.insideUnitSphere;
        randomSpawnPoint =
            new Vector3(randomSpawnPoint.x * _radiusX, randomSpawnPoint.y, randomSpawnPoint.z * _radiusZ);
        randomSpawnPoint.y = 0.5f;

        // seeker pos
        // transform.position = randomSpawnPoint;

        // newTurtleInstance.transform.position = randomSpawnPoint;
    }


    // wait for frame to finish destroying old turtle
    IEnumerator InstantiateTurtle()
    {
        yield return new WaitForEndOfFrame();
        // Debug.Log("after destroy: " + GameObject.FindGameObjectsWithTag("Turtle").Length);
        RandomizePositionAfterTurtle();
    }

    private void OnDrawGizmos()
    {
        // draw debug sphere to visualize random sphere
        // Gizmos.DrawWireSphere(transform.position, _radius);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GameObject.FindGameObjectsWithTag("Turtle").Length);

        if (newTurtleInstance.transform.position == target.transform.position)
        {
            // maybe add logic to also delete newTurtleInstance after it is being used instead of original newTurtleInstance
            Destroy(newTurtleInstance);

            // Debug.Log("after destroy: " + GameObject.FindGameObjectsWithTag("Turtle").Length);
            StartCoroutine(InstantiateTurtle());
        }
    }
}