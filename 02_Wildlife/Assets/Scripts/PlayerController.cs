using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed = 10f;
    private float horizontalInput;
    private float xRange = 15.0f;

    public GameObject projectilePrefab;
    
    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (speed * Time.deltaTime * horizontalInput));
        
        if (transform.position.x < -15) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 15) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}