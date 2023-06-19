using System.Collections;
using System.Collections.Generic;
using AnimationEaseInOut;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public enum FlyOrAttack
{
    FlyMode,
    AttackMode
};

public class AIBirdMovement2 : MonoBehaviour
{
    private GameObject turtle;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float radius;
    private float duration;
    private float timer;
    private float speed = 10f;
    private Animator _animator;
    private Vector3 randomPosition;
    private Vector3 targetPosition;


    private FlyOrAttack _flyOrAttack;

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
        turtle = GameObject.FindGameObjectWithTag("Turtle");
        GetComponent<NavMeshAgent>().enabled = false;

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, turtle.transform.position, step);
    }

    private void FlyUpAgain()
    {
        print("I am inside Flyupagain");
        _flyOrAttack = FlyOrAttack.FlyMode;
        var step = speed * Time.deltaTime;
        Vector3 target = new Vector3(0, 19.2f, 0);

        // transform.forward = Vector3.RotateTowards(transform.forward,
        //     target, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, target, step);
        print(transform.position.y);

        if (transform.position.y == 19.2f)
        {
            print("should be up again");
            _flyOrAttack = FlyOrAttack.AttackMode;
            GetComponent<NavMeshAgent>().enabled = true;
            print("NavMeshAgent enabled");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _flyOrAttack = FlyOrAttack.AttackMode;
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("Attack", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.1f)
        {
            _flyOrAttack = FlyOrAttack.FlyMode;
        }

        timer += Time.deltaTime;
        print(timer);

        if (_flyOrAttack == FlyOrAttack.AttackMode && timer >= 10)
        {
            // AssignTargetPosition();
            _animator.SetBool("Attack", true);
            DiveTowardsTurtle();
        }

        turtle = GameObject.FindGameObjectWithTag("Turtle");


        if (_flyOrAttack == FlyOrAttack.FlyMode)
        {
            _animator.SetBool("Attack", false);
            FlyUpAgain();
            AssignTargetPosition();
            timer = 0f;
        }

        if (GetComponent<NavMeshAgent>().enabled)
        {
            transform.position = navMeshAgent.nextPosition;
        }
    }
}