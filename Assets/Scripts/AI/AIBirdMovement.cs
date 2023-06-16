using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBirdMovement : MonoBehaviour
{
    private GameObject turtle;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float radius;

    private void AssignTargetPosition()
    {
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        Vector3 targetPosition = transform.position + randomPosition;

        NavMeshHit navMeshHit;
        if (NavMesh.SamplePosition(targetPosition, out navMeshHit, radius, 1))
        {
            navMeshAgent.SetDestination(targetPosition);
        }
    }

    private void DiveTowardsTurtle()
    {
        turtle = GameObject.FindGameObjectWithTag("Turtle");

        // Debug.Log("turtle pos for bird: " + turtle.transform.position + "bird pos: " + navMeshAgent.transform.position);

        navMeshAgent.SetDestination(turtle.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.velocity == new Vector3(0, 0, 0))
        {
            // AssignTargetPosition();
            DiveTowardsTurtle();
        }

        transform.position = navMeshAgent.nextPosition;
    }
}