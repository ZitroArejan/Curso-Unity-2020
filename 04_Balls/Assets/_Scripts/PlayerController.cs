using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    public bool hasPowerUp;
    public float moveSpeed;
    public float pushForce;
    public float powerUpTime;
    private float verticalInput;
    
    public GameObject relativeTo;
    public GameObject[] powerUpIndicators;
    private Rigidbody _rigidbody;
    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * (verticalInput * moveSpeed * Time.deltaTime), relativeTo.transform);
        _rigidbody.AddForce(relativeTo.transform.forward * (verticalInput * moveSpeed));
        foreach (GameObject indicator in powerUpIndicators) {
            indicator.transform.position = transform.position + 0.7f * Vector3.down;
        }

        if (transform.position.y < -5) {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PowerUp")) {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp) {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pushDirection = (enemyRigidbody.gameObject.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDown() {
        foreach (var indicator in powerUpIndicators) {
            indicator.SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            indicator.SetActive(false);
        }
        hasPowerUp = false;
    }
}