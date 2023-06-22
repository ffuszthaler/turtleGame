using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrashSpawnRandomizer : MonoBehaviour
{
    private float _radius = 30f;

    private Vector3 CalculatePossibleSpawnPoints()
    {
        Vector3 randomSpawnPoint = Random.insideUnitSphere * _radius;
        randomSpawnPoint.y = 0.1f;

        return randomSpawnPoint;
    }

    private void OnDrawGizmos()
    {
        // draw debug sphere to visualize random sphere
        // Gizmos.DrawWireSphere(transform.position, _radius);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = CalculatePossibleSpawnPoints();
    }


    // Update is called once per frame
    void Update()
    {
    }
}