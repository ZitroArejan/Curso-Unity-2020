using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public int enemyCount;
    public int enemyWave;
    
    private float spawnRange = 7;
    
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    
    void Start() {
        float powerUpDelay = 5;
        float powerUpRate = Random.Range(8, 15);
        //SpawnEnemyWave(enemyWave);
        InvokeRepeating("SpawnPowerUp", powerUpDelay,powerUpRate );
    }

    void Update() {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0) {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
        }
    }

    /// <summary>
    /// Genera una posicion aleatoria dentro de la zona de juego
    /// </summary>
    /// <returns>Devuelve una posicion aleatoria dentro de la zona de juego</returns>
    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    /// <summary>
    /// Método que genera un número de enemigos en pantalla
    /// </summary>
    /// <param name="numberOfEnemies">Cantidad de enemigos a generar</param>
    private void SpawnEnemyWave( int numberOfEnemies) {
        for (int i = 0; i < numberOfEnemies; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    /// <summary>
    /// Genera un power up dentro de la zona de juego
    /// </summary>
    private void SpawnPowerUp() {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }
}