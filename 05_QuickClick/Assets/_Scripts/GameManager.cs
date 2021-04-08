using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float spawnRate;
    
    public List<GameObject> targetPrefabs;
    
    void Start() {
        StartCoroutine(SpawnTarget());
    }

    void Update() {
        
    }

    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }
}