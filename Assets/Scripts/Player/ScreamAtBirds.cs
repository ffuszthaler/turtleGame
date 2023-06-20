using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreamAtBirds : MonoBehaviour
{
    private GameObject bird;
    private GameObject turtle;


    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindWithTag("Seagull");
    }

    void OnPickup(InputValue input)
    {
        RaycastHit birdRayCast = PlayerRaycast.ShootRay();

        if (birdRayCast.collider.tag == "Seagull")
        {
            Destroy(birdRayCast.collider.gameObject);
            ScreamAtBird();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // turtle = AIBirdMovement.turtle;
        // // print(turtle);
        // if (turtle != null)
        // {
        //     float turtlePlayerDistance = Vector3.Distance(transform.parent.position, turtle.transform.position);
        //     //print(turtlePlayerDistance);
        //     if (turtlePlayerDistance <= 7f && AIBirdMovement._flyOrAttack == FlyOrAttack.AttackMode)
        //     {
        //         AIBirdMovement._flyOrAttack = FlyOrAttack.FlyMode;
        //         print(AIBirdMovement._flyOrAttack);
        //     }
        //     else
        //     {
        //         AIBirdMovement._flyOrAttack = FlyOrAttack.AttackMode;
        //     }
        // }
        // else
        // {
        //     AIBirdMovement._flyOrAttack = FlyOrAttack.AttackMode;
        // }
        //
        // print("Stat in Scream at bird" + AIBirdMovement._flyOrAttack);
    }

    private void ScreamAtBird()
    {
        // PlaySound()
        AIBirdMovement._flyOrAttack = FlyOrAttack.FlyMode;
    }
}