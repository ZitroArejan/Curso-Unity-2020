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
    private int numberOfLives = 4;
    private float spawnRate = 1.8f;
    private const string MAX_SCORE = "MAX_SCORE";

    public int Score {
        get => _score;
        set => _score = Mathf.Max(value, 0);
    }

    public List<GameObject> targetPrefabs;
    public List<GameObject> lives;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject gameOverScreen;

    void Start() {
        gameOverScreen.SetActive(false);
        titleScreen.SetActive(true);
        ShowMaxScore();
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
        numberOfLives -= difficulty - 1;
        for (int i = 0; i < numberOfLives; i++) {
            lives[i].SetActive(true);
        }
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
    /// Extrae y muestra la puntuación máxima del juego
    /// </summary>
    public void ShowMaxScore() {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Max Score\n" + maxScore;
    }

    /// <summary>
    /// Actualiza la puntuación máxima del juego si es superada
    /// </summary>
    private void SetMaxScore() {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (Score > maxScore) {
            PlayerPrefs.SetInt(MAX_SCORE, Score);
        }
    }

    /// <summary>
    /// Lanza el evento Game Over del juego
    /// </summary>
    public void GameOver() {
        numberOfLives--;
        if (numberOfLives >= 0) {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.2f;
            heartImage.color = tempColor;
        }
        if (numberOfLives <= 0) {
            gameState = GameState.gameOver;
            gameOverScreen.SetActive(true);
            SetMaxScore();
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}