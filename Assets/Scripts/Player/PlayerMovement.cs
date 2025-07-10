using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float fastSpeed, slowSpeed;

    [SerializeField]
    private Animator gardenerBroomAnimator;

    [SerializeField]
    private GameObject dirtVFX;

    private Vector3 originalPosition;
    private bool finishGame;

    private float currentSpeed;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        originalPosition = transform.position;

        SpeedUpPlayer();
        gameObject.SetActive(false);

        FinishGameManager.LoseGame += StopPlayer;
        UIStartGame.StartGameAction += OnStartGame;

        UIHomeButton.ResetGameAction += ResetGame;
        finishGame = false;
    }

    private void FixedUpdate()
    {
        if (finishGame) return;
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

    public void StopPlayer()
    {
        finishGame = true;
        playerRigidbody.velocity = Vector3.zero;
        if (!gardenerBroomAnimator.gameObject.activeInHierarchy) return;
        gardenerBroomAnimator.Play("Idle");
        dirtVFX.SetActive(false);
    }

    private void ResetGame()
    {
        finishGame = false;
        SpeedUpPlayer();
        dirtVFX.SetActive(true);

        PlayerToolManager.ChangeToolAction?.Invoke(1);
        transform.position = originalPosition;
        gameObject.SetActive(false);
    }
    private void OnStartGame()
    {
        gameObject.SetActive(true);
    }
}
