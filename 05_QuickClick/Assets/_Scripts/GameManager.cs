using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    private float spawnRate = 2;
    private int _score;

    public int Score {
        get => _score;
        set => _score = Mathf.Max(value, 0);
    }

    public List<GameObject> targetPrefabs;
    public TextMeshProUGUI scoreText;

    void Start() {
        StartCoroutine(SpawnTarget());
        Score = 0;
        UpdateScore(0);
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

    /// <summary>
    /// Actualiza la puntuación y lo muestra en pantalla
    /// </summary>
    /// <param name="scoreToAdd">Puntos a añadir a la puntuación global</param>
    public void UpdateScore(int scoreToAdd) {
        Score += scoreToAdd;
        scoreText.text = "Score\n" + Score;
    }
}