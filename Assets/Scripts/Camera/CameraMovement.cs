using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    private Vector3 originalPosition = new Vector3(18.37f, 10.18f, 13.11f);
    private Vector3 originalRotation = new Vector3(14.92f, -120, 0);
    private void Awake()
    {
        gameObject.transform.position = originalPosition;
        gameObject.transform.eulerAngles = originalRotation;

        UIStartGame.StartGameAction += OnStartGame;
    }

    private void OnStartGame()
    {
        gameObject.transform.parent = playerTransform;

        gameObject.transform.localPosition = new Vector3(12.4f, 9.3f, -6f);
        gameObject.transform.localEulerAngles = new Vector3(16.7f, -60.5f, 0);
    }
}
