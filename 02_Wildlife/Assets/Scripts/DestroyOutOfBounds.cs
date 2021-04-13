using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {
    private float topBound = 30f;
    private float bottomBound = -2;

    void Update() {
        if (transform.position.z > topBound) {
            Destroy(gameObject);
        }

        if (transform.position.z < bottomBound) {
            Debug.Log("Game Over!!");
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}