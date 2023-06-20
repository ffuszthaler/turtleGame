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
    public bool isMoveForward = true;
    public int currentCoordID = 0;
    public int nextCoordID = 1;
    private float _rotateSpeed = 3.0f;
    private float _accumulatedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // get refrence to aStar through tag
        // required for new turtle instance to find aStar gameobject
        // uninitialized prefabs cannnot access exiting gameobjects
        aStar = GameObject.FindWithTag("aStar");
        _grid = aStar.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_grid.Path == null)
            return;

        // Debug.Log("path array index: " + nextCoordID);
        // move the object forward
        if (isMoveForward)
        {
            WalkForward();

            if (currentCoordID == _grid.Path.Count - 1)
            {
                // Debug.Log("astar done");
                // _isMoveForward = !_isMoveForward;
                // _currentCoordID = 0;
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
            _grid.Path[nextCoordID].WorldPos - transform.position, _rotateSpeed * Time.deltaTime, 0.0f);

        _accumulatedTime += Time.deltaTime;

        transform.position = EaseInOut.MoveTowardSmoothstep(_grid.Path[currentCoordID].WorldPos,
            _grid.Path[nextCoordID].WorldPos, _accumulatedTime);

        // move to the next edge segment
        if (transform.position == _grid.Path[nextCoordID].WorldPos)
        {
            currentCoordID++;

            if (currentCoordID <= _grid.Path.Count - 2)
            {
                nextCoordID = currentCoordID + 1;
                _accumulatedTime = 0;
            }
            else
            {
                nextCoordID = _grid.Path.Count() - 2;
                _accumulatedTime = 0;
                currentCoordID--;
            }
        }
    }

    void WalkBackward()
    {
        // rotate toward the target 
        transform.forward = Vector3.RotateTowards(transform.forward,
            _grid.Path[nextCoordID].WorldPos - transform.position, _rotateSpeed * Time.deltaTime, 0.0f);

        _accumulatedTime += Time.deltaTime;

        transform.position = EaseInOut.MoveTowardSmoothstep(_grid.Path[currentCoordID].WorldPos,
            _grid.Path[nextCoordID].WorldPos, _accumulatedTime);

        // move to the next edge segment
        if (transform.position == _grid.Path[nextCoordID].WorldPos)
        {
            currentCoordID--;

            if (currentCoordID >= 1)
            {
                nextCoordID = currentCoordID - 1;
                _accumulatedTime = 0;
            }
            else
            {
                nextCoordID = 1;
                _accumulatedTime = 0;
            }
        }
    }
}