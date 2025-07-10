using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float fastSpeed, slowSpeed;

    [SerializeField]
    private Animator gardenerBroomAnimator;

    [SerializeField]
    private GameObject dirtVFX;

    private Rigidbody enemyRigidbody;
    private float currentSpeed;

    private Vector3 originalPosition;
    private bool finishRace;

    private void Awake()
    {
        finishRace = false;
        originalPosition = transform.position;

        enemyRigidbody = GetComponent<Rigidbody>();
        gameObject.SetActive(false);

        SpeedUpEnemy();

        FinishGameManager.WinGame += StopEnemy;
        UIStartGame.StartGameAction += OnStartGame;

        UIHomeButton.ResetGameAction += ResetGame;
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
        finishRace = true;
        if (!gardenerBroomAnimator.gameObject.activeInHierarchy) return;
        dirtVFX.SetActive(false);
        gardenerBroomAnimator.Play("Idle");
    }

    private void ResetGame()
    {
        finishRace = false;
        dirtVFX.SetActive(true);

        EnemyToolManager.EnemyChangeTool?.Invoke(1);
        SpeedUpEnemy();

        transform.position = originalPosition;
        gameObject.SetActive(false);
    }
    private void OnStartGame()
    {
        gameObject.SetActive(true);
    }
}
