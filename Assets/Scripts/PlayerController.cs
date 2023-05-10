using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;


    //Movement
    [SerializeField] private float speed; //Speed of player movement
    [SerializeField] private float smoothTime = 0.05f; //How smooth the player turns
    private float _currentVelocity;


    //Gravity
    private float _gravity = -9.81f; //Gravity of falling
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;



    //Jumping
    [SerializeField] private float jumpPower; //How high you can jump

    

    

    public void Awake()
    {
        
        _characterController = GetComponent<CharacterController>();
    }


    public void Update()
    {
        ApplyRotation();
        ApplyMovement();
        ApplyGravity();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }

    
    


    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }
    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }
    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        _direction.y = _velocity;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }
        if (!IsGrounded())
        {
            return;
        }

        _velocity += jumpPower;
    }

    

    private bool IsGrounded() => _characterController.isGrounded;




    

    
}
