using System;

using UnityEngine;
using UnityEngine.UI;

public class UIHomeButton : MonoBehaviour
{
    public static Action ResetGameAction;

    [SerializeField]
    private Canvas menuCanvas, gameStateCanvas;

    private Button homeButton;

    private void Awake()
    {


        homeButton = GetComponent<Button>();
        homeButton.onClick.AddListener(ReturnHome);
    }

    private void ReturnHome()
    {
        menuCanvas.enabled = true;
        gameStateCanvas.enabled = false;

        ResetGameAction?.Invoke();
    }
}
