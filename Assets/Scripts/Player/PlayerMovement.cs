using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed;

    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        gameObject.SetActive(false);
        UIStartGame.StartGameAction += OnStartGame;
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = Vector3.forward * runSpeed;
    }

    private void OnStartGame()
    {
        gameObject.SetActive(true);
    }
}
