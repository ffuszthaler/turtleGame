using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;
using AnimationEaseInOut;

public class PathWalk : MonoBehaviour
{
    public GameObject aStar;

    private Grid _grid;

    // variables for ease-in ease-out functions
    public bool _isMoveForward = true;
    private int _currentCoordID = 0;
    private int _nextCoordID = 1;
    private float _rotateSpeed = 3.0f;
    private float _accumulatedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _grid = aStar.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        // move the object forward
        if (_isMoveForward)
        {
            WalkForward();

            if (_currentCoordID == _grid.Path.Count - 1)
            {
                _isMoveForward = !_isMoveForward;
            }
        }
        // move the object backward
        else
        {
            // WalkBackward();
            //
            // if (_currentCoordID == 0)
            // {
            //     _isMoveForward = !_isMoveForward;
            // }
        }
    }

    void WalkForward()
    {
        // rotate toward the target 
        transform.forward = Vector3.RotateTowards(transform.forward,
            _grid.Path[_nextCoordID].WorldPos - transform.position, _rotateSpeed * Time.deltaTime, 0.0f);

        _accumulatedTime += Time.deltaTime;

        transform.position = EaseInOut.MoveTowardSmoothstep(_grid.Path[_currentCoordID].WorldPos,
            _grid.Path[_nextCoordID].WorldPos, _accumulatedTime);

        // move to the next edge segment
        if (transform.position == _grid.Path[_nextCoordID].WorldPos)
        {
            _currentCoordID++;

            if (_currentCoordID <= _grid.Path.Count - 2)
            {
                _nextCoordID = _currentCoordID + 1;
                _accumulatedTime = 0;
            }
            else
            {
                _nextCoordID = _grid.Path.Count() - 2;
                _accumulatedTime = 0;
            }
        }
    }

    void WalkBackward()
    {
        // rotate toward the target 
        transform.forward = Vector3.RotateTowards(transform.forward,
            _grid.Path[_nextCoordID].WorldPos - transform.position, _rotateSpeed * Time.deltaTime, 0.0f);

        _accumulatedTime += Time.deltaTime;

        transform.position = EaseInOut.MoveTowardSmoothstep(_grid.Path[_currentCoordID].WorldPos,
            _grid.Path[_nextCoordID].WorldPos, _accumulatedTime);

        // move to the next edge segment
        if (transform.position == _grid.Path[_nextCoordID].WorldPos)
        {
            _currentCoordID--;

            if (_currentCoordID >= 1)
            {
                _nextCoordID = _currentCoordID - 1;
                _accumulatedTime = 0;
            }
            else
            {
                _nextCoordID = 1;
                _accumulatedTime = 0;
            }
        }
    }
}