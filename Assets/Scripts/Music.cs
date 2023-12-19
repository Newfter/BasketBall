using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    public static Music Instance;
    
    [SerializeField] AudioSource BackgroundMusic;
    [SerializeField] private AudioMixerGroup soundsGroup;
    private bool isEnadle = true, soundsEnable = true;
    private void Start()
    {
        isEnadle = PlayerPrefs.GetInt("music") == 1;
        PlayerPrefs.SetInt("music",1);

        soundsEnable = PlayerPrefs.GetInt("sounds") == 1;
        PlayerPrefs.SetInt("sounds",1);
        
        BackgroundMusic.enabled = isEnadle;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnableMusic()
    {
        isEnadle = !isEnadle;
        BackgroundMusic.enabled = isEnadle;
        if (isEnadle) PlayerPrefs.SetInt("music",1);
        else PlayerPrefs.SetInt("music",0);
    }
}
