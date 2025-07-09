using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float fastSpeed, slowSpeed;

    [SerializeField]
    private Animator gardenerBroomAnimator;

    private Rigidbody enemyRigidbody;
    private float currentSpeed;

    private bool finishRace;

    private void Awake()
    {
        finishRace = false;

        enemyRigidbody = GetComponent<Rigidbody>();
        gameObject.SetActive(false);

        SpeedUpEnemy();
        UIStartGame.StartGameAction += OnStartGame;
    }

    private void FixedUpdate()
    {
        if (finishRace) return;
        enemyRigidbody.velocity = Vector3.forward * currentSpeed;
    }

    public void SpeedUpEnemy()
    {
        currentSpeed = fastSpeed;
    }

    public void SlowDownEnemy()
    {
        currentSpeed = slowSpeed;
    }

    public void StopEnemy()
    {
        enemyRigidbody.velocity = Vector3.zero;
        gardenerBroomAnimator.Play("Idle");
        finishRace = true;

    }

    private void OnStartGame()
    {
        gameObject.SetActive(true);
    }
}
