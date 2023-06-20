using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRaycast : MonoBehaviour
{
    public static PlayerRaycast Instance;

    // void OnPickup(InputValue input)
    // {
    //     ShootRay();
    // }

    public static RaycastHit ShootRay()
    {
        RaycastHit raycastHit;

        bool hasHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.magenta);

        // TODO: maybe move this to its own file
        if (hasHit)
        {
            // if (raycastHit.collider.tag == "Trash")
            // {
            //     Destroy(raycastHit.collider.gameObject);
            //     GameStats.Instance.IncreaseTrashScore(1);
            // }
            return raycastHit;
        }
        else
        {
            return raycastHit;
        }
    }

    // public void ShootRay()
    // {
    //     RaycastHit raycastHit;
    //
    //     bool hasHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit);
    //
    //     Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.magenta);
    //
    //     // TODO: maybe move this to its own file
    //     if (hasHit)
    //     {
    //         if (raycastHit.collider.tag == "Trash")
    //         {
    //             Destroy(raycastHit.collider.gameObject);
    //             GameStats.Instance.IncreaseTrashScore(1);
    //         }
    //     }
    // }

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