using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomizeInitialTarget : MonoBehaviour
{
    public GameObject target;
    public GameObject seeker;

    public GameObject aStar;
    private Grid _grid;

    private Vector3 randomSpawnPoint;
    private readonly float _radiusX = 8f;
    private readonly float _radiusZ = 8f;

    public void CalculateInitialRandomTargetPosition()
    {
        randomSpawnPoint = Random.insideUnitSphere;

        randomSpawnPoint = new Vector3(
            randomSpawnPoint.x * _radiusX + transform.position.x,
            0.5f,
            randomSpawnPoint.z * _radiusZ + transform.position.z
        );

        randomSpawnPoint = new Vector3(Mathf.Round(randomSpawnPoint.x), Mathf.Round(randomSpawnPoint.y),
            Mathf.Round(randomSpawnPoint.z));
        target.transform.position = randomSpawnPoint;
    }

    // Start is called before the first frame update
    void Start()
    {
        aStar = GameObject.FindWithTag("aStar");
        _grid = aStar.GetComponent<Grid>();

        CalculateInitialRandomTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // issue position of turtle and target never quite match after turtle reaches target because of the grid inaccuracy
        // if (transform.position == target.transform.position)
        if (transform.position == _grid.Path.Last().WorldPos)
        {
            seeker.transform.position = transform.position;
            target.transform.position = new Vector3(-2.5f, 0f, 11f);
        }
    }
}