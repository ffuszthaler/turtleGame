using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreamAtBirds : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void onPickUp(InputValue input)
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
       
        
    }

    private void ScreamAtBird()
    {
        // PlaySound()
        AIBirdMovement2._flyOrAttack = FlyOrAttack.FlyMode;
    }
}
