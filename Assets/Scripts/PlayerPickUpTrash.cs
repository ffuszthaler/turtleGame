using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpTrash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnPickup(InputValue input)
    {
        RaycastHit trashHit = PlayerRaycast.ShootRay();
        
        if (trashHit.collider.tag == "Trash")
        {
            Destroy(trashHit.collider.gameObject);
            GameStats.Instance.IncreaseTrashScore(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
