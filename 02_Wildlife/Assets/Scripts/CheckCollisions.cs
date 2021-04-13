using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckCollisions : MonoBehaviour {
    private void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Projectile")) {
            Destroy(this.gameObject);   //Destruye al enemigo
            Destroy(col.gameObject);    //Destruye al proyectil
        }
    }
}