using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float fastSpeed, slowSpeed;

    [SerializeField]
    private Animator gardenerBroomAnimator;

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

    public void StopPlayer()
    {
        currentSpeed = 0;
        gardenerBroomAnimator.Play("Idle");
    }

    private void OnStartGame()
    {
        gameObject.SetActive(true);
    }
}
