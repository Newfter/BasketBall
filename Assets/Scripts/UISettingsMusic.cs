using UnityEngine;
using UnityEngine.UI;

public class UISettingsMusic : MonoBehaviour
{
    [SerializeField] private Toggle toggleMusic, toogleSounds;

    private void Start()
    {
        toggleMusic.isOn = Music.Instance.isMusicEnable;
        toogleSounds.isOn = Music.Instance.isSoundEnable;
    }

    public void EnebleToogleMusic(bool state)
    {
        Music.Instance.SwitchMusic(state);
    }

    public void EnableToogleSounds(bool state)
    {
        Music.Instance.SwitchSounds(state);
    }
}