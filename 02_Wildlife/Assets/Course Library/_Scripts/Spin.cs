using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    public float translateSpeed = 1;
    public float rotateSpeed = 180;
    
    void Start() {
        
    }

    void Update() {
        transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
        transform.localPosition += Vector3.left * (translateSpeed * Time.deltaTime);
    }
}