using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpTrash : MonoBehaviour
{
    void OnPickup(InputValue input)
    {
        RaycastHit raycastHit = PlayerRaycast.ShootRay();

        if (raycastHit.collider.tag == "Trash")
        {
            Destroy(raycastHit.collider.gameObject);
            GameStats.Instance.IncreaseTrashScore(1);
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