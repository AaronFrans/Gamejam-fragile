using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class _playerMovement : MonoBehaviour
{


    CharacterController _controller;

    [SerializeField]
    public float _movementSpeed = 6.0f;

    [SerializeField]
    public float _jumpforce = 5.0f;
  
    [SerializeField]
    public float _rotationSpeed = 5.0f;

    [SerializeField]
    private Camera _followCamera;

    Rigidbody _playerRigidBody;
    Vector3 _playerVelocity;
    bool _isOnGround = true;
    private float _gravityValue = -9.81f;


    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        _isOnGround = _controller.isGrounded;
        if(_isOnGround && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0;
        }

        //Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y ,0) * new Vector3(horizontal, 0f, vertical).normalized;

        _controller.Move(movementInput * _movementSpeed * Time.deltaTime);
        //print(movementInput);
        if(movementInput != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementInput, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }

        
        if(Input.GetButtonDown("Jump") && _isOnGround)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpforce * -3.0f * _gravityValue);
        }

        _playerVelocity.y += (_gravityValue * 3f) * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);

    }

    void MovePlayer()
    {
        //Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Put the input into a vectors
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        //Check if there is any input, otherwise return.
        if (direction.magnitude >= 0.1f)
        {
            _controller.Move(direction * _movementSpeed * Time.deltaTime);
         //      //Get angle between the direction of player and camera rotation
         //      float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
         //     
         //      //Make it so player doesn't snap at angle, but rather moves towards it smoothly
         //      float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
         //      transform.rotation = Quaternion.Euler(0f, angle, 0f);
         //     
         //      //Make the player move in the direction of the camera rotation.
         //      Vector3 movementDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
         //     
         //      //Move the player in the world space.
         //      //_controller.Move(movementDirection.normalized * _movementSpeed * Time.deltaTime);
         //     
         //      transform.position = movementDirection * Time.deltaTime;
        }
    }

    void LetPlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _playerRigidBody.AddForce(Vector3.up * _jumpforce, ForceMode.Impulse);
            _isOnGround = false;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isOnGround = true;
        }
         
    }
}
