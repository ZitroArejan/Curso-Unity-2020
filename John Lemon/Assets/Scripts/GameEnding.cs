using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour {
    private bool isPlayerAtExit, isPlayerCaught;
    private bool hasAudioPlayed;
    private float fadeDuration = 1;
    private float timer;
    private float displayImageDuration = 1;

    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource exitAudio, caughtAudio;
    
    public bool IsPlayerCaught {
        get => isPlayerCaught;
        set => isPlayerCaught = value;
    }

    private void Update() {
        if (isPlayerAtExit) {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        } else if (isPlayerCaught) {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            isPlayerAtExit = true;
        }
    }

    /// <summary>
    /// Termina el nivel de juego
    /// <param name="canvasGroup">Imagen de fin de partida correspondiente</param></summary>
    private void EndLevel(CanvasGroup canvasGroup, bool doRestart, AudioSource audioSource) {
        if (!hasAudioPlayed) {
            audioSource.Play();
            hasAudioPlayed = true;
        }
        timer += Time.deltaTime;
        canvasGroup.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration) {
            if (doRestart) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } else {
                Application.Quit();
            }
        }
    }
}