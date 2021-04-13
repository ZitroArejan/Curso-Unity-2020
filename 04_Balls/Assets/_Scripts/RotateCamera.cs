using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {
    public float rotateSpeed;
    
    private float horizontalInput;
    
    void Start() {
        
    }

    void Update() {
        //horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * (-horizontalInput * rotateSpeed * Time.deltaTime));
    }
}