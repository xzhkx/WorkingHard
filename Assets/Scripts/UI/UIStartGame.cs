using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartGame : MonoBehaviour
{
    public static Action StartGameAction;

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Canvas menuCanvas, gameplayCanvas;

    [SerializeField]
    private GameObject toolButtons;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        gameplayCanvas.enabled = false;
    }

    private void StartGame()
    {
        menuCanvas.enabled = false;
        gameplayCanvas.enabled = true;
        toolButtons.SetActive(false);
        StartGameAction?.Invoke();
    }
}
