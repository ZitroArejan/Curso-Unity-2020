using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {
    [Range(1, 5)]
    public int difficulty;
    
    private GameManager gameManager;
    private Button _button;
    
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty() {
        gameManager.StartGame(difficulty);
    }
}