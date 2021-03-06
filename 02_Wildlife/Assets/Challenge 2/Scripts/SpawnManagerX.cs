using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManagerX : MonoBehaviour {
    public GameObject[] ballPrefabs;

    private int randomIndex;
    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    private float counter = 0;
    private float nextWaitTime = 5;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    private void Update() {
        counter += Time.deltaTime;
        if (counter >= nextWaitTime) {
            counter = 0;
            nextWaitTime = Random.Range(2, 6);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall () {
        randomIndex = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomIndex], spawnPos, ballPrefabs[randomIndex].transform.rotation);
    }
}