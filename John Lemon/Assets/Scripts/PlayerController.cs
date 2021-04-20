#if UNITY_ANDROID || UNITY_IOS
    #define USING_MOBILE
#endif

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float turnSpeed;
    private const string IS_WALKING = "IsWalking";
    private const string SPEED_MULTIPLIER = "SpeedMultiplier";
    
    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private AudioSource _audioSource;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            _animator.SetFloat(SPEED_MULTIPLIER, 1.5f);
        } else {
            _animator.SetFloat(SPEED_MULTIPLIER, 1);
        }
    }

    void FixedUpdate() {
        #if USING_MOBILE
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if (Input.touchCount > 0) {
                horizontalInput = Input.touches[0].deltaPosition.x;
                verticalInput = Input.touches[0].deltaPosition.y;
            }
        #else
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
        #endif
        
        
        movement.Set(horizontalInput, 0, verticalInput);
        movement.Normalize();
        
        bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0);
        bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0);
        bool isWalking = hasVerticalInput || hasHorizontalInput;

        if (isWalking) {
            if (!_audioSource.isPlaying) {
                _audioSource.Play();
            }
        } else {
            _audioSource.Stop();
        }
        
        _animator.SetBool(IS_WALKING, isWalking);
        Vector3 desiredFoward = Vector3.RotateTowards(transform.forward, movement,
            turnSpeed * Time.fixedDeltaTime, 0);
        rotation = Quaternion.LookRotation(desiredFoward);
    }

    private void OnAnimatorMove() {
        _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(rotation);
    }
}