using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRaycast : MonoBehaviour
{
    public float RayCastDistance;

    void OnPickup(InputValue input)
    {
        ShootRay();
    }

    void ShootRay()
    {
        RaycastHit raycastHit;

        bool hasHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit,
            RayCastDistance);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.magenta);

        // TODO: maybe move this to its own file
        if (hasHit)
        {
            if (raycastHit.collider.tag == "Trash")
            {
                Destroy(raycastHit.collider.gameObject);
                GameStats.Instance.IncreaseTrashScore(1);
            }

            // test logic
            if (raycastHit.collider.tag == "Turtle")
            {
                Destroy(raycastHit.collider.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ShootRay();
    }
}