using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour {
    private int randomIndex;
    private float startDelay = 1;
    private float repeatRate = 3;

    public GameObject[] obstaclePrefabs;
    private PlayerController1 _playerController1;
    
    private Vector3 spawnPos;
    void Start() {
        spawnPos = transform.position;
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
        _playerController1 = GameObject.FindWithTag("Player").GetComponent<PlayerController1>();
    }
    
    void Update() {
        
    }

    private void spawnObstacle() {
        if (!_playerController1.GameOver) {
            randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomIndex], spawnPos, obstaclePrefabs[randomIndex].transform.rotation);
        }
    }
}