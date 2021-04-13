using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour {
    public int animalIndex;
    
    private float spawnRangeX = 14;
    private float spawnPosZ;
    [SerializeField]
    private float startDelay = 2;
    [SerializeField]
    private float spawnInterval = 2;
    
    public GameObject[] enemies;

    private void Start() {
        spawnPosZ = transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void Update() {
        
    }

    private void SpawnRandomAnimal() {
        animalIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(enemies[animalIndex], spawnPos , enemies[animalIndex].transform.rotation);
    }
}