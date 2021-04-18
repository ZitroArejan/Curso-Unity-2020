using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour {
    private bool isPlayerAtExit;
    [SerializeField]
    private float fadeDuration = 1;
    private float timer;
    private float displayImageDuration = 1;

    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;

    private void Update() {
        if (isPlayerAtExit) {
            timer += Time.deltaTime;
            exitBackgroundImageCanvasGroup.alpha = timer / fadeDuration;
            if (timer > fadeDuration + displayImageDuration) {
                EndLevel();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            isPlayerAtExit = true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void EndLevel() {
        Application.Quit();
    }
}