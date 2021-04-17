using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float turnSpeed;
    private const string IS_WALKING = "IsWalking";
    
    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;

    private Rigidbody _rigidbody;
    private Animator _animator;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        movement.Set(horizontalInput, 0, verticalInput);
        movement.Normalize();
        
        bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0);
        bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0);
        bool isWalking = hasVerticalInput || hasHorizontalInput;
        
        _animator.SetBool(IS_WALKING, isWalking);
        Vector3 desiredFoward = Vector3.RotateTowards(transform.forward, movement,
            turnSpeed * Time.deltaTime, 0);
        rotation = Quaternion.LookRotation(desiredFoward);
    }

    private void OnAnimatorMove() {
        _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(rotation);
    }
}