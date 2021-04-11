using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public enum GameState {
        inGame,
        paused,
        loading,
        gameOver
    }

    public GameState gameState;
    
    private int _score;
    private float spawnRate = 1;

    public int Score {
        get => _score;
        set => _score = Mathf.Max(value, 0);
    }

    public List<GameObject> targetPrefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    void Start() {
        gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        Score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    void Update() {
        
    }

    IEnumerator SpawnTarget() {
        while (gameState == GameState.inGame) {
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

    /// <summary>
    /// Lanza el evento Game Over del juego
    /// </summary>
    public void GameOver() {
        gameState = GameState.gameOver;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}