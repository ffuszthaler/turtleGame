using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreamAtBirds : MonoBehaviour
{
    private void ScreamAtBird()
    {
        // PlaySound()
        // AIBirdMovement._flyOrAttack = FlyOrAttack.FlyMode;
    }

    void OnPickup(InputValue input)
    {
        RaycastHit raycastHit = PlayerRaycast.ShootRay();

        if (raycastHit.collider.tag == "Seagull")
        {
            Destroy(raycastHit.collider.gameObject);
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