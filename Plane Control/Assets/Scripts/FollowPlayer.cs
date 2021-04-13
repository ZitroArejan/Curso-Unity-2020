using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private float distance = 30f;
    
    public GameObject player;

    //public Vector3 offset = new Vector3(0, 8, -18);
    private Vector3 playerPreviousPos = Vector3.zero;
    
    void Update()
    {
        Vector3 offset = player.transform.position - playerPreviousPos;
        offset.Normalize();
        transform.position = player.transform.position - offset * distance;
        transform.LookAt(player.transform.position);
        playerPreviousPos = player.transform.position;
    }
}