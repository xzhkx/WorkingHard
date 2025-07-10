using UnityEngine.UI;
using UnityEngine;

public class UIHome : MonoBehaviour
{

    private Button homeButton;

    private void Awake()
    {
        homeButton = GetComponent<Button>();
        homeButton.onClick.AddListener(ReturnHome);
    }

    private void ReturnHome()
    {
        Time.timeScale = 1;
        UIHomeButton.ResetGameAction?.Invoke();
    }
}
