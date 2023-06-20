using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRaycast : MonoBehaviour
{
    public static PlayerRaycast Instance;

    public static RaycastHit ShootRay()
    {
        RaycastHit raycastHit;

        bool hasHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.magenta);

        if (hasHit)
        {
            return raycastHit;
        }
        else
        {
            return raycastHit;
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