using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed = 35f;
    private float turnSpeed = 50f;

    private float verticalInput;
    private float horizontalInput;
    
    void Update() {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        transform.Rotate(Vector3.right * (turnSpeed * Time.deltaTime * verticalInput));
        transform.Rotate(Vector3.up * (turnSpeed * Time.deltaTime * horizontalInput));
    }
}
