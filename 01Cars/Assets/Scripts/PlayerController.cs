using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Range(0, 20), SerializeField, Tooltip("Velocidad del coche")]
    private float speed = 20.0f;
    
    [Range(0, 90), SerializeField, Tooltip("Velocidad de giro del coche")]
    private float turnSpeed = 30f;
    
    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        //Debug.Log("Movimiento: " + horizontalInput);
        transform.Translate(Vector3.forward * (speed * Time.deltaTime * verticalInput));
        transform.Rotate(Vector3.up * (turnSpeed * Time.deltaTime * horizontalInput));
    }
}