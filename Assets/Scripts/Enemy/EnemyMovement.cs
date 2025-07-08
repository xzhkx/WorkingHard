using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed;

    private Rigidbody enemyRigidbody;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();

        gameObject.SetActive(false);
        UIStartGame.StartGameAction += OnStartGame;
    }

    private void FixedUpdate()
    {
        enemyRigidbody.velocity = Vector3.forward * runSpeed;
    }

    private void OnStartGame()
    {
        gameObject.SetActive(true);
    }
}
