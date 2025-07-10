using UnityEngine.UI;
using UnityEngine;

public class UIMuteButton : MonoBehaviour
{
    [SerializeField]
    private Button soundButton;

    private Button muteButton;

    private void Awake()
    {
        muteButton = GetComponent<Button>();
        muteButton.onClick.AddListener(TurnOnSound);
    }

    private void TurnOnSound()
    {
        SoundManager.PlaySound(0);

        SoundManager.Instance.TurnOnSound();
        soundButton.gameObject.SetActive(true);
    }
}
