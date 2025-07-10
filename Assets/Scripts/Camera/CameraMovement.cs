using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    private Vector3 originalPosition = new Vector3(18.37f, 10.18f, 13.11f);
    private Vector3 originalRotation = new Vector3(14.92f, -120, 0);

    private Vector3 targetPosition = new Vector3(15f, 9.5f, -6.5f);
    private Vector3 targetRotation = new Vector3(15f, -65.5f, 0);
    private void Awake()
    {
        gameObject.transform.position = originalPosition;
        gameObject.transform.eulerAngles = originalRotation;

        UIStartGame.StartGameAction += OnStartGame;
        UIHomeButton.ResetGameAction += ResetGame;
    }

    private void OnStartGame()
    {
        gameObject.transform.parent = playerTransform;

        gameObject.transform.localPosition = targetPosition;
        gameObject.transform.localEulerAngles = targetRotation;
    }

    private void ResetGame()
    {
        gameObject.transform.parent = null;

        gameObject.transform.position = originalPosition;
        gameObject.transform.eulerAngles = originalRotation;
    }
}
