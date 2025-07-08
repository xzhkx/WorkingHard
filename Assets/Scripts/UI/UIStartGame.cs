using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartGame : MonoBehaviour
{
    public static Action StartGameAction;

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Canvas menuCanvas;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        menuCanvas.enabled = false;
        StartGameAction?.Invoke();
    }
}
