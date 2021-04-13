using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    public bool usePhysicsEngine;
    public float moveSpeed, rotateSpeed, force;
    public float jumpForce = 10;
    public float gravityMultiplier = 2.5f;
    
    private float verticalInput, horizontalInput;
    private Vector3 GRAVITY = new Vector3(0, -9.81f, 0);

    private Rigidbody _rigidbody;
    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity = GRAVITY * gravityMultiplier;
    }

    void Update() {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        MovePlayer();
        KeepPlayerInBounds();
        if (Input.GetKeyDown(KeyCode.Space)) {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void MovePlayer() {
        if (usePhysicsEngine) {
            //_rigidbody.AddForce(new Vector3(horizontalInput, 0, verticalInput) * (speed * Time.deltaTime));
            _rigidbody.AddForce(Vector3.forward * (verticalInput * force * Time.deltaTime));
            _rigidbody.AddTorque(Vector3.up * (horizontalInput * force * Time.deltaTime));
        } else {
            transform.Translate(Vector3.forward * (verticalInput * moveSpeed * Time.deltaTime));
            transform.Rotate(Vector3.up * (horizontalInput * rotateSpeed * Time.deltaTime));
        }
    }

    private void KeepPlayerInBounds() {
        if (Mathf.Abs(transform.position.x) >= 24 || Mathf.Abs(transform.position.z) >= 24) {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > 24) {
                transform.position = new Vector3(24, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -24) {
                transform.position = new Vector3(-24, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 24) {
                transform.position = new Vector3(transform.position.y, transform.position.y, 24);
            }
            if (transform.position.z < -24) {
                transform.position = new Vector3(transform.position.y, transform.position.y, -24);
            }
        }
    }
}