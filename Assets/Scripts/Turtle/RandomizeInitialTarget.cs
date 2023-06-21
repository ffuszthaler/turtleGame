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

    private PathWalk _pathWalk;

    private Vector3 randomSpawnPoint;
    private readonly float _radiusX = 4f;
    private readonly float _radiusZ = 4f;

    // [SerializeField] private Vector3 _finalTurtlePosition = new Vector3(-2.5f, 0f, -9f);
    [SerializeField] private Vector3 _finalTurtlePosition;
    private bool _hasHitFirstTarget = false;

    public void CalculateInitialRandomTargetPosition()
    {
        randomSpawnPoint = Random.insideUnitSphere;

        randomSpawnPoint = new Vector3(
            randomSpawnPoint.x * _radiusX + transform.position.x,
            0.5f,
            randomSpawnPoint.z * _radiusZ + transform.position.z
        );

        randomSpawnPoint = new Vector3(Mathf.Round(randomSpawnPoint.x), randomSpawnPoint.y,
            Mathf.Round(randomSpawnPoint.z));
        target.transform.position = randomSpawnPoint;

        // _finalTurtlePosition = randomSpawnPoint;
    }

    // Start is called before the first frame update
    void Start()
    {
        _finalTurtlePosition = target.transform.position;
        aStar = GameObject.FindWithTag("aStar");
        // seeker = GameObject.FindWithTag("aStar_Seeker");
        // target = GameObject.FindWithTag("aStar_Target");

        _grid = aStar.GetComponent<Grid>();

        _pathWalk = GetComponent<PathWalk>();

        CalculateInitialRandomTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        AStar.Instance.FindPath(seeker.transform.position, target.transform.position);

        if (transform.position == _grid.Path.Last().WorldPos && !_hasHitFirstTarget)
        {
            _hasHitFirstTarget = true;

            // reposition seeker to last current turtle position before starting 2nd astar
            seeker.transform.position = transform.position;

            // reset next id
            _pathWalk.currentCoordID = 0;
            _pathWalk.nextCoordID = 1;

            // reassign target to new/final turtle position
            target.transform.position = _finalTurtlePosition;
        }

        // if turtle reaches final target position, stop astar
        if (_grid.NodeFromWorldPoint(transform.position) == _grid.NodeFromWorldPoint(_finalTurtlePosition))
        {
            _pathWalk.isMoveForward = false;
            Destroy(gameObject);
            GameStats.Instance.IncreaseTurtleScore(1);
        }
    }
}