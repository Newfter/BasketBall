using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    public static Music Instance;
    
    [SerializeField] AudioSource BackgroundMusic;
    public AudioMixer mixer;
    public bool isMusicEnable,isSoundEnable;
    private void Awake()
    {
        isMusicEnable = PlayerPrefs.GetInt("music") == 1;
        isSoundEnable = PlayerPrefs.GetInt("sounds") == 1;
        BackgroundMusic.enabled = isMusicEnable;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void SwitchMusic(bool state)
    {
        isMusicEnable = state;
        BackgroundMusic.enabled = isMusicEnable;
        if (isMusicEnable) PlayerPrefs.SetInt("music",1);
        else PlayerPrefs.SetInt("music",0);
    }

    public void SwitchSounds(bool state)
    {
        isSoundEnable = state;

        if (isSoundEnable) mixer.SetFloat("Sound", 0);
        else mixer.SetFloat("Sound", -80);
        
        if (isSoundEnable) PlayerPrefs.SetInt("sounds",1);
        else PlayerPrefs.SetInt("sounds",0);
        
        
    }
}
