using System;
using UnityEngine;

public class FinishGameManager : MonoBehaviour
{
    public static Action WinGame;
    public static Action LoseGame;

    [SerializeField]
    private Canvas gameStateCanvas, gameplayCanvas;

    [SerializeField]
    private GameObject winState, loseState;

    private Camera mainCamera;

    private void Awake()
    {
        gameStateCanvas.enabled = false;
        mainCamera = Camera.main;
        WinGame += OnWinGame;
        LoseGame += OnLoseGame;
    }

    private void OnWinGame()
    {
        mainCamera.transform.parent = null;

        gameStateCanvas.enabled = true;
        gameplayCanvas.enabled = false;

        winState.SetActive(true);
        loseState.SetActive(false);
    }

    private void OnLoseGame()
    {
        mainCamera.transform.parent = null;

        gameStateCanvas.enabled = true;
        gameplayCanvas.enabled = false;

        winState.SetActive(false);
        loseState.SetActive(true);
    }
}
