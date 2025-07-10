using UnityEngine;
using UnityEngine.UI;

public class UISoundButton : MonoBehaviour
{
    private Button soundButton;

    private void Awake()
    {
        soundButton = GetComponent<Button>();
        soundButton.onClick.AddListener(MuteSound);
    }

    private void MuteSound()
    {
        SoundManager.PlaySound(0);

        SoundManager.Instance.MuteSound();
        soundButton.gameObject.SetActive(false);
    }
}
