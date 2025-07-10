using UnityEngine;

public enum SoundType
{
    UI_CLICK,
    FIRE_EX,
    BROOM,
    WATERING,
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField]
    private AudioClip[] audioClips;

    [SerializeField]
    private AudioSource BGM;

    private AudioSource audioSource;
    private bool isMute;
    private void Awake()
    {
        Instance = this;
        isMute = false;
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(int soundID, float volume = 1)
    {
        if (Instance.isMute)
        {
            return;
        }
        Instance.audioSource.PlayOneShot(Instance.audioClips[soundID], volume);
    }

    public void MuteSound()
    {
        isMute = true;
        BGM.Stop();
    }

    public void TurnOnSound()
    {
        BGM.Play();
        isMute = false;
    }
}
