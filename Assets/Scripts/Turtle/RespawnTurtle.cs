using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// this probably needs to be renamed
public class RespawnTurtle : MonoBehaviour
{
    private Vector3 _initialSeekerPosition = new Vector3(-2.5f, 0, -20f);

    public GameObject turtlePrefab;
    public GameObject newTurtleInstance;

    private void Respawn()
    {
        if (GameObject.FindGameObjectsWithTag("Turtle").Length == 0)
        {
            // reset random seeker position to initial
            transform.position = _initialSeekerPosition;

            // instantiate new turtle
            newTurtleInstance = Instantiate(turtlePrefab, transform.position, transform.rotation);

            // randomly spawn multiple ones
        }
    }


    // wait for frame to finish destroying old turtle
    IEnumerator InstantiateTurtle()
    {
        yield return new WaitForEndOfFrame();
        // Debug.Log("after destroy: " + GameObject.FindGameObjectsWithTag("Turtle").Length);
        Respawn();
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
        // StartCoroutine(InstantiateTurtle());
        Respawn();
    }
}