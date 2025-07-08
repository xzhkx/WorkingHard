using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartGame : MonoBehaviour
{
    public static Action StartGameAction;

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Image nameImage;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        startButton.gameObject.SetActive(false);
        nameImage.enabled = false;

        StartGameAction?.Invoke();
    }
}
