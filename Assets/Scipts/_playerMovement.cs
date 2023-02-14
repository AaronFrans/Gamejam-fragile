using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEditor;
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
        if (!SlopeSliding())
            Movement();
        else
            SlopeSliding();
    }

    void Movement()
    {
        _isOnGround = _controller.isGrounded;
        if (_isOnGround && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0;
        }

        //Get input
        float horizontal = Input.GetAxisRaw("Horizontal");
     
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y ,0) * new Vector3(horizontal, 0f, vertical).normalized;

        _controller.Move(movementInput * _movementSpeed * Time.deltaTime);

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

    Action OnNextDrawGizmos;
    void OnDrawGizmos() 
    {
        OnNextDrawGizmos?.Invoke();
        OnNextDrawGizmos = null;
    }

    bool SlopeSliding()
    {
        if(_isOnGround)
        {
            var sphereCastVerticalOffset = _controller.height / 2 - _controller.radius;
            var castOrigin = transform.position - new Vector3(0, sphereCastVerticalOffset, 0);
            



            if(Physics.SphereCast(castOrigin, _controller.radius - .01f, Vector3.down,
                out var hit, .05f, ~LayerMask.GetMask("Player"), QueryTriggerInteraction.Ignore))
            {
                var collider = hit.collider;
                var angle = Vector3.Angle(Vector3.up, hit.normal);

                //Debug angle of surface and the normal of that surface

               //Debug.DrawLine(hit.point, hit.point + hit.normal, Color.black, 3f);
               //OnNextDrawGizmos += () =>
               //{
               //    GUI.color = Color.black;
               //    Handles.Label(transform.position + new Vector3(0, 2f, 0), "Angle: " + angle.ToString());
               //};


                if(angle > _controller.slopeLimit)
                {
                    var normal = hit.normal;
                    var yInverse = 1f - normal.y;
                    _playerVelocity.x += yInverse * normal.x;
                    _playerVelocity.z += yInverse * normal.z;


                    _controller.Move(_playerVelocity * Time.deltaTime);
                    return true;
                }

                 _playerVelocity.x = 0f;
                 _playerVelocity.z = 0f;
                return false;
            }

            return false;
        }
        return false;
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
}
