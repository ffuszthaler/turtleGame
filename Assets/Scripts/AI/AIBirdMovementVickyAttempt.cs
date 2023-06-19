using System.Collections;
using System.Collections.Generic;
using AnimationEaseInOut;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AIBirdMovementVickyAttempt : MonoBehaviour
{
    private Vector3 randomPosition;
    private Vector3 targetPosition;
    private float interceptorSpeed = 3f;
    private GameObject turtle;
    private Rigidbody rb;  

    private Vector3 theDir;

    private NavMeshAgent navMeshAgent;
    [SerializeField] private float radius;

    private void AssignTargetPosition()
    {
        randomPosition = Random.insideUnitSphere * radius;
        targetPosition = transform.position + randomPosition;

        NavMeshHit navMeshHit;
        if (NavMesh.SamplePosition(targetPosition, out navMeshHit, radius, 1))
        {
            navMeshAgent.SetDestination(targetPosition);
        }
    }

    private void DiveTowardsTurtle()
    {
        turtle = GameObject.FindGameObjectWithTag("Turtle");
        GetComponent<NavMeshAgent>().enabled = false;
        

        transform.position = EaseInOut.MoveTowardSmoothstep(transform.position, theDir, interceptorSpeed);


        // Debug.Log("turtle pos for bird: " + turtle.transform.position + "bird pos: " + navMeshAgent.transform.position);

        // navMeshAgent.SetDestination(turtle.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = turtle.GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        theDir = CalculateInterceptCourse.CalculateBirdAttackCourse(turtle.transform.position, rb.velocity,
            transform.position, interceptorSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        DiveTowardsTurtle();

        // if (navMeshAgent.velocity == new Vector3(0, 0, 0))
        // {
        //     // AssignTargetPosition();
        //     DiveTowardsTurtle();
        // }

        // transform.position = navMeshAgent.nextPosition;
    }
}