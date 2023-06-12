using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerBody;

    private float _rotationX;
    private float _rotationY;

    public float mouseSensitivity;

    void OnLook(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();
        // good idea?
        // inputVector.Normalize();

        var playerTransform = playerBody.GetComponent<Transform>();

        // x axis with clamping to limit up and down movement
        _rotationX -= inputVector.y * Time.deltaTime * mouseSensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -90, 90);

        // y axis without to allow full rotations
        _rotationY += inputVector.x * Time.deltaTime * mouseSensitivity;

        // Debug.Log("CAMERA - ROTATION: " + _rotationX + ", " + _rotationY);

        // rotate camera according to mouse
        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

        // rotate player according to camera
        playerTransform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        // lock cursor inside window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = playerBody.transform.position;
        transform.position = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 0.7f,
            playerBody.transform.position.z + 0.3f);
    }
}