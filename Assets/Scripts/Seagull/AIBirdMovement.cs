using System;
using System.Collections;
using System.Collections.Generic;
using AnimationEaseInOut;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public enum FlyOrAttack
{
    FlyMode,
    AttackMode
};

public class AIBirdMovement : MonoBehaviour
{
    private GameObject[] turtles;
    public static GameObject turtle;
    private GameObject player;

    private bool turtleSelected = false;


    private NavMeshAgent navMeshAgent;
    [SerializeField] private float radius;

    private float duration;
    private float timer;
    private float speed = 5f;

    private Animator _animator;

    private Vector3 randomPosition;
    private Vector3 targetPosition;

    public static FlyOrAttack _flyOrAttack;

    private void AssignTargetPosition()
    {
        randomPosition = Random.insideUnitSphere * radius;
        targetPosition = transform.position + randomPosition;

        NavMeshHit navMeshHit;
        if (NavMesh.SamplePosition(targetPosition, out navMeshHit, radius, 1) && GetComponent<NavMeshAgent>().enabled)
        {
            navMeshAgent.SetDestination(targetPosition);
        }
    }

    private void DiveTowardsTurtle()
    {
        if (!turtleSelected)
        {
            turtles = GameObject.FindGameObjectsWithTag("Turtle");
            var randomIndex = Random.Range(0, turtles.Length);
            print(randomIndex);
            turtle = turtles[randomIndex];
            turtleSelected = true;
        }

        GetComponent<NavMeshAgent>().enabled = false;

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, turtle.transform.position, step);

        var lookPos = turtle.transform.position - transform.position;

        Quaternion lookRot = Quaternion.LookRotation(lookPos);

        lookRot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, lookRot.eulerAngles.y,
            transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }

    private void FlyUpAgain()
    {
        turtle = null;
        turtleSelected = false;

        // print("I am inside Flyupagain")
        print("State in Flyupagain: " + _flyOrAttack);
        var step = speed * Time.deltaTime;
        Vector3 target = new Vector3(0, 19.2f, 0);

        transform.LookAt(target);

        // transform.forward = Vector3.RotateTowards(transform.forward,
        //     target, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, target, step);
        // print(transform.position.y);

        if (transform.position.y == 19.2f)
        {
            // print("should be up again");
            _flyOrAttack = FlyOrAttack.AttackMode;
            print("enum in Flyupagain if the bird is up: " + _flyOrAttack);


            GetComponent<NavMeshAgent>().enabled = true;
            AssignTargetPosition();
            // print("NavMeshAgent enabled");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _flyOrAttack = FlyOrAttack.FlyMode;
        print("State in Start: " + _flyOrAttack);

        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("Attack", false);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        if (turtle != null)
        {
            float turtlePlayerDistance = Vector3.Distance(player.transform.position, turtle.transform.position);
            print(turtlePlayerDistance);

            if (transform.position.y < 1f || turtlePlayerDistance <= 10f)
            {
                _flyOrAttack = FlyOrAttack.FlyMode;
                print("state in update: " + _flyOrAttack);
            }
            else
            {
                _flyOrAttack = FlyOrAttack.AttackMode;
            }
        }

        timer += Time.deltaTime;
        // print(timer);

        if (_flyOrAttack == FlyOrAttack.AttackMode && timer >= 10)
        {
            // AssignTargetPosition();
            _animator.SetBool("Attack", true);
            DiveTowardsTurtle();
        }
        else if (_flyOrAttack == FlyOrAttack.AttackMode && timer <= 10 && navMeshAgent.velocity == Vector3.zero)
        {
            AssignTargetPosition();
        }

        if (_flyOrAttack == FlyOrAttack.FlyMode)
        {
            _animator.SetBool("Attack", false);
            FlyUpAgain();
            timer = 0f;
        }

        if (navMeshAgent.enabled)
        {
            transform.position = navMeshAgent.nextPosition;
        }
    }
}