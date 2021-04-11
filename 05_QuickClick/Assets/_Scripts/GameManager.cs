using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    public enum GameState {
        inGame,
        paused,
        loading,
        gameOver
    }

    public GameState gameState;
    
    private int _score;
    private float spawnRate = 1.8f;

    public int Score {
        get => _score;
        set => _score = Mathf.Max(value, 0);
    }

    public List<GameObject> targetPrefabs;
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI gameOverText;
    //public Button restartButton;
    public GameObject titleScreen;
    public GameObject gameOverScreen;

    void Start() {
        //gameOverText.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);
        gameOverScreen.SetActive(false);
        titleScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Método que inicia la partida y configura la dificultad
    /// </summary>
    /// <param name="difficulty">Número entero que indica el grado de dificultad del juego</param>
    public void StartGame(int difficulty) {
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        gameState = GameState.inGame;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        Score = 0;
        UpdateScore(0);
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
        //gameOverText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        gameOverScreen.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}