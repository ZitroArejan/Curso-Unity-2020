using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour {
    [Range(-50, 50)]
    public int pointValue;
    private float minForce = 10.5f, maxForce = 14, torque = 1, xRange = 3.5f, ySpawnPos = -1.5f, zSpawnPos = 0.5f;

    public ParticleSystem explosionParticle;
    private GameManager gameManager;
    private Rigidbody _rigidbody;
    
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    void Update() {
        
    }

    /// <summary>
    /// Genera un vector aleatorio de tres dimensiones
    /// </summary>
    /// <returns>Fuerza aleatoria hacia arriba</returns>
    private Vector3 RandomForce() {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    /// <summary>
    /// Genera un número aleatorio
    /// </summary>
    /// <returns>Valor aleatorio entre -torque y torque</returns>
    private float RandomTorque() {
        return Random.Range(-torque, torque);
    }

    /// <summary>
    /// Genera un posición aleatoria
    /// </summary>
    /// <returns>Posición aleatoria de tres dimensiones</returns>
    private Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, zSpawnPos);
    }

    private void OnMouseDown() {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("KillZone")) {
            Destroy(gameObject);
            if (pointValue > 0) {
                gameManager.UpdateScore(-pointValue);
            }
        }
    }
}