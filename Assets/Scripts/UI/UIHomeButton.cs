using System;
using UnityEngine;

public class UIHomeButton : MonoBehaviour
{
    public static Action ResetGameAction;

    [SerializeField]
    private Canvas menuCanvas, gameStateCanvas, gameplayCanvas;

    [SerializeField]
    private GameObject pausePanel;

    private void Awake()
    {
        ResetGameAction += ResetGame;
    }

    private void ResetGame()
    {
        menuCanvas.enabled = true;
        gameStateCanvas.enabled = false;
        pausePanel.SetActive(false);
        gameplayCanvas.enabled = false; 
    }
}
