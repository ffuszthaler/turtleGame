using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpTrash : MonoBehaviour
{
    void OnPickup(InputValue input)
    {
        RaycastHit trashHit = PlayerRaycast.ShootRay();
        
        print(trashHit.collider.tag);
        
        if (trashHit.collider.tag == "Trash")
        {
            Destroy(trashHit.collider.gameObject);
            GameStats.Instance.IncreaseTrashScore(1);
        }
    }

}
