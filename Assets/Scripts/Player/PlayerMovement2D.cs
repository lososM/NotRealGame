using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    private Vector3 _direction;
    private bool _hadJump;
    [SerializeField] Vector3 _correctIsGround;

    private Rigidbody2D rigidbody;
   

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        InputGetter.JumpEvent += Jump;
        InputGetter.Horizontal += SetDirection;
       
    }
    public void SetDirection(float horizontal)
    {
        _direction = new Vector3(horizontal, 0);
    }
    public void Jump()
    {
        if (IsGround()) { 
            
            _hadJump = true;
        
        }
    }
   
    private bool IsGround()
    {
        return Physics2D.Raycast(transform.position + _correctIsGround, Vector2.down, .01f);
    }
    private void FixedUpdate()
    {
        var velocity = new Vector3(_direction.x * _speed, rigidbody.velocity.y);
        

        if (_hadJump)
        {
            velocity.y = _jumpForce;
            _hadJump = false;
        }
        rigidbody.velocity =  velocity;
    }
  
}
