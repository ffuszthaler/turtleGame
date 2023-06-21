using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreamAtBirds : MonoBehaviour
{
    private void ScreamAtBird()
    {
        Transform player = transform.parent.GetChild(1);

        if (AIBirdMovement.turtle != null)
        {
            float distanceTurtlePlayer =
                Vector3.Distance(player.position, AIBirdMovement.turtle.transform.position);

            print("Distance: " + distanceTurtlePlayer);

            if (distanceTurtlePlayer >= 5f)
            {
                return;
            }
            else
            {
                AIBirdMovement._flyAwayEnabled = true;
                AIBirdMovement._diveDownEnabled = false;
            }
        }
    }

    void OnScream(InputValue input)
    {
        RaycastHit raycastHit = PlayerRaycast.ShootRay();

        if (raycastHit.collider.tag == "Seagull")
        {
            AIBirdMovement._flyAwayEnabled = true;
            ScreamAtBird();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}