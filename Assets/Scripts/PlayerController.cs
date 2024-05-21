using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;
    public bool hasKey1 = false;
    public bool hasKey2 = false;
    public bool hasKey3 = false;
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
        if(other.name == "key 2 to 5")
        {
            Destroy(other.gameObject);
            hasKey1 = true;
        }
        else if (other.name == "key 5 to 4")
        {
            Destroy(other.gameObject);
            hasKey2 = true;
        }
        else if (other.name == "key 1 to 2")
        {
            Destroy(other.gameObject);
            hasKey3 = true;
        }
        if (other.tag == "Chicken")
        {
            if (GetComponent<HungerManager>().hungerValue >= 70)
            {
                GetComponent<HungerManager>().hungerValue = 100;
            }
            else
            {
                GetComponent<HungerManager>().hungerValue += 30;                
            }
            Destroy(other.gameObject);
            this.GetComponent<HungerManager>().DrawHunBar();
        }





    }
    

}
