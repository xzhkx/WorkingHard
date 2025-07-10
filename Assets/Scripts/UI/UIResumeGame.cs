using UnityEngine;
using UnityEngine.UI;

public class UIResumeGame : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    private Button resumeButton;

    private void Awake()
    {
        resumeButton = GetComponent<Button>();
        resumeButton.onClick.AddListener(ResumeGame);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
