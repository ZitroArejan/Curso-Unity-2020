using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
    public float speed = 10;

    private PlayerController1 _playerController1;
        
    void Start() {
        _playerController1 = GameObject.FindWithTag("Player").GetComponent<PlayerController1>();
    }
    
    void Update() {
        
        if (!_playerController1.GameOver) {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}