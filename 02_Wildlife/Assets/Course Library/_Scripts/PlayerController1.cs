using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController1 : MonoBehaviour {
    public bool isOnGround = true;
    public float jumpForce;
    public float gravityMultiplier;
    [Range(0, 1)]
    public float audioVolume;
    
    private bool _gameOver;
    private float speedMultiplier = 1;
    private const string SPEED_F = "Speed_f";
    private const string SPEED_MULTIPLIER = "Speed multiplier";
    private const string JUMP_TRIG = "Jump_trig";
    private const string JUMP_B = "Jump_b";
    private const string DEATH_B = "Death_b";
    private const string DEATHTYPE_INT = "DeathType_int";
    
    public ParticleSystem explosion, dirt;
    public AudioClip jumpSound, crashSound;
    
    private Rigidbody playerRb;
    private Animator _animator;
    private AudioSource _audioSource;

    public bool GameOver => _gameOver;

    void Start() {
        playerRb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);
        _animator.SetFloat(SPEED_F, 1);
        dirt.Play();
    }
    
    void Update() {
        speedMultiplier += Time.deltaTime;
        _animator.SetFloat(SPEED_MULTIPLIER, (speedMultiplier / 60));
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirt.Stop();
            _animator.SetTrigger(JUMP_TRIG);
            _animator.SetBool(JUMP_B, true);
            _audioSource.PlayOneShot(jumpSound, audioVolume);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground") && !_gameOver) {
            _animator.SetBool(JUMP_B, false);
            dirt.Play();
            isOnGround = true;
        }
        if (other.gameObject.CompareTag("Obstacle")) {
            explosion.Play();
            dirt.Stop();
            _audioSource.PlayOneShot(crashSound, audioVolume);
            _animator.SetInteger(DEATHTYPE_INT, Random.Range(1, 3));
            _animator.SetBool(DEATH_B, true);
            _gameOver = true;
            Invoke("RestartGame", 2);
        }
    }

    private void RestartGame() {
        SceneManager.LoadScene("Prototype 3");
    }
}