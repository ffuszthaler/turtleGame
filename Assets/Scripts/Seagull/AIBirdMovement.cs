using System;
using System.Collections;
using System.Collections.Generic;
using AnimationEaseInOut;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public enum FlyOrAttack
{
    PatrolMode,
    FlyUpMode,
    AttackMode
};

public class AIBirdMovement : MonoBehaviour
{
    private GameObject[] turtles;
    public static GameObject turtle;

    private bool turtleSelected = false;

    private NavMeshAgent navMeshAgent;
    [SerializeField] private float radius;

    private float duration;
    private float timer;
    private float timerLimit;
    private float speed = 10f;

    private Animator _animator;

    private Vector3 randomPosition;
    private Vector3 targetPosition;

    public static FlyOrAttack _flyOrAttack;

    public static bool _flyAwayEnabled;
    public static bool _diveDownEnabled;

    private bool _defaultState;
    private bool hasHitTurtle;


    void StateHandler()
    {
        if (_flyAwayEnabled && transform.position.y < 19.2f)
        {
            _flyOrAttack = FlyOrAttack.FlyUpMode;
            _animator.SetBool("Attack", false);
            timer = 0f;
        }
        else if (_diveDownEnabled)
        {
            _flyOrAttack = FlyOrAttack.AttackMode;
            _animator.SetBool("Attack", true);
        }
        else if (_defaultState)
        {
            _flyOrAttack = FlyOrAttack.PatrolMode;
            _animator.SetBool("Attack", false);
        }
    }

    void BirdMovementController()
    {
        if (transform.position.y <= 1f || _flyAwayEnabled)
        {
            _flyAwayEnabled = true;
            _diveDownEnabled = false;
        }

        if (timer >= timerLimit && transform.position.y >= 18f && !_flyAwayEnabled)
        {
            _diveDownEnabled = true;

            // if (turtle != null)
            // {
            //     turtle.GetComponent<TurtleStats>().ReduceHealth(1);
            //     turtle.GetComponent<TurtleStats>().healthDecreased = false;
            // }
        }
        else
        {
            _defaultState = true;
            return;
        }
    }

    // when not in attack mode

    private void AssignTargetPosition()
    {
        if (_flyAwayEnabled || _diveDownEnabled)
        {
            return;
        }
        else if (navMeshAgent.velocity != Vector3.zero)
        {
            return;
        }

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
        if (!_diveDownEnabled || _flyAwayEnabled)
        {
            return;
        }

        if (!turtleSelected)
        {
            turtles = GameObject.FindGameObjectsWithTag("Turtle");
            var randomIndex = Random.Range(0, turtles.Length);
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
        if (!_flyAwayEnabled)
        {
            return;
        }


        turtleSelected = false;

        var step = speed * Time.deltaTime;
        Vector3 target = new Vector3(0, 19.2f, 0);

        transform.LookAt(target);

        // transform.forward = Vector3.RotateTowards(transform.forward,
        //     target, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (transform.position.y == 19.2f)
        {
            timerLimit = Random.Range(10, 20);

            _flyAwayEnabled = false;
            GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger");

        if (other.CompareTag("Turtle"))
        {
            other.GetComponent<TurtleStats>().ReduceHealth(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timerLimit = 10f;

        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        StateHandler();
        BirdMovementController();
        DiveTowardsTurtle();
        FlyUpAgain();
        AssignTargetPosition();


        if (navMeshAgent.enabled)
        {
            transform.position = navMeshAgent.nextPosition;
        }
    }
}