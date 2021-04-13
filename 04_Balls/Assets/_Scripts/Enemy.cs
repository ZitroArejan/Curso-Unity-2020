using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float moveForce;
    private GameObject player;
    private Rigidbody _rigidbody;
    void Start() {
        player = GameObject.Find("Player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        _rigidbody.AddForce(lookDirection * moveForce , ForceMode.Force);
        if (transform.position.y < -5) {
            Destroy(gameObject);
        }
    }
}