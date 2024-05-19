using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Door0;
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;
    public bool hasKey = false;
    public Animator animator;

    private float _fallVelocity = 0;
    private Vector3 _moveVector;

    private CharacterController _characterController;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    
    }
    void Update()
    {
        MovementUpdate();
        JumpUpdate();
    }

    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        var runDirection = 0;



        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDirection = 1;
        }
        animator.SetInteger("runDirection", runDirection);
    }
    
    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
    
    void FixedUpdate()
    {
      _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

      _fallVelocity += gravity * Time.fixedDeltaTime; 

      _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

      if (_characterController.isGrounded)
      {
          _fallVelocity = 0;
      }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "key")
        {
            Destroy(other.gameObject);
            hasKey = true;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.name == "Door0" && hasKey == true)
        {
            Destroy(other.gameObject);
        }
    }

}
