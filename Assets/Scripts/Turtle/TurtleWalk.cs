using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

// enum MovementState
// {
//     towardsSeeker = 0,
//     towardsTarget = 1
// };

public class TurtleWalk : MonoBehaviour
{
    // public float speed;
    public GameObject target;

    private Vector3 randomSpawnPoint;
    private readonly float _radiusX = 8f;
    private readonly float _radiusZ = 8f;

    // private MovementState _movementState = MovementState.towardsSeeker;

    // private bool hasReachedRandomStartPoint = false;

    // public void CalculateInitialRandomTargetPosition()
    // {
    //     randomSpawnPoint = Random.insideUnitSphere;
    //     randomSpawnPoint = new Vector3(
    //         randomSpawnPoint.x * _radiusX + transform.position.x,
    //         0.5f,
    //         randomSpawnPoint.z * _radiusZ + transform.position.z
    //     );
    //
    //     target.transform.position = randomSpawnPoint;
    // }

    // void StartPathWalk()
    // {
    // }

    private void OnDrawGizmos()
    {
        // draw debug sphere to visualize random sphere
        Gizmos.DrawWireSphere(randomSpawnPoint, _radiusX);
        Gizmos.DrawWireSphere(randomSpawnPoint, _radiusZ);
    }

    // Start is called before the first frame update
    void Start()
    {
        // CalculateInitialRandomTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("turt: " + transform.position);

        // if (_movementState == MovementState.towardsSeeker && !hasReachedRandomStartPoint)
        // if (_movementState == MovementState.towardsSeeker)
        // {
        //     // float step = speed * Time.deltaTime;
        //     //     transform.position = Vector3.MoveTowards(transform.position, randomSpawnPoint, step);
        //
        //     if (transform.position == randomSpawnPoint)
        //     {
        //         // hasReachedRandomStartPoint = true;
        //         _movementState = MovementState.towardsTarget;
        //         GetComponent<PathWalk>().enabled = true;
        //     }
        // }

        if (transform.position == randomSpawnPoint && target.transform.position == randomSpawnPoint)
        {
            // turtles has reached the first position of target (1st is randomly calculated)
// maybe use two targets
        }


        // target.transform.position = Vector3.MoveTowards(target.transform.position, randomSpawnPoint, step);

        // if (transform.position == randomSpawnPoint && target.transform.position == randomSpawnPoint)
        // {
        //     StartPathWalk();
        // }
    }
}