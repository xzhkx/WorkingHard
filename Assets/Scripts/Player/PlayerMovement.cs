using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float fastSpeed, slowSpeed;

    private float currentSpeed;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        SpeedUpPlayer();
        gameObject.SetActive(false);

        UIStartGame.StartGameAction += OnStartGame;
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = Vector3.forward * currentSpeed;
    }

    public void SlowDownPlayer()
    {
        currentSpeed = slowSpeed;
    }

    public void SpeedUpPlayer()
    {
        currentSpeed = fastSpeed;
    }

    private void OnStartGame()
    {
        gameObject.SetActive(true);
    }
}
