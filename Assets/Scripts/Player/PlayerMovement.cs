using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _moveBy;
    public float walkSpeed;

    // private bool _isWalking;

    void OnWalk(InputValue input)
    {
        var inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void Movement()
    {
        // Debug.Log(transform.position);

        // if (_moveBy == Vector3.zero)
        // {
        //     _isWalking = false;
        // }
        // else
        // {
        //     _isWalking = true;
        // }

        transform.Translate(_moveBy * (walkSpeed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall1" || collision.gameObject.name == "Wall2")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}