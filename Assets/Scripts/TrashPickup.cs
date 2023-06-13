using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    //Trash sounds could be implemented here?

    // [field: SerializeField] public float TrashHealth { private set; get; }
    // public static TrashPickup Instance;
    //
    // public void PickUpTrash()
    // {
    //     if (TrashHealth == 0f)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // Debug.Log("Enemy Health: " + enemyHealth);

    private float _radius = 30f;

    private Vector3 CalculatePossibleSpawnPoints()
    {
        Vector3 randomSpawnPoint = Random.insideUnitSphere * _radius;
        randomSpawnPoint.y = 0.5f;

        return randomSpawnPoint;
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