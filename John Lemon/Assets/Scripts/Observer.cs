using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour {
    private bool isPlayerInRange;
    
    public Transform player;
    public GameEnding gameEnding;

    private void Update() {
        if (isPlayerInRange) {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction, Color.magenta, Time.deltaTime, true);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit)) {
                if (raycastHit.collider.transform == player) {
                    gameEnding.IsPlayerCaught = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform == player) {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform == player) {
            isPlayerInRange = false;
        }
    }
}