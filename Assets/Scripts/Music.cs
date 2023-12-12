using UnityEngine;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundMusic, BasketballSounds;
    private bool isEnadle = true; 
    [SerializeField] private Toggle toogle, toogle2;
    public bool sounds;
    private void Start()
    {
        isEnadle = PlayerPrefs.GetInt("music") == 1;
        PlayerPrefs.SetInt("music",1);
        toogle.isOn = isEnadle;
        BackgroundMusic.enabled = isEnadle;
        sounds = PlayerPrefs.GetInt("sounds") == 1;
        PlayerPrefs.SetInt("sounds",1);
        toogle2.isOn = sounds;
        BasketballSounds.enabled = sounds;

    }

    public void EnableMusic()
    {
        isEnadle = !isEnadle;
        BackgroundMusic.enabled = isEnadle;
        if (isEnadle) PlayerPrefs.SetInt("music",1);
        else PlayerPrefs.SetInt("music",0);
    }

    public void Sounds()
    {
        sounds = !sounds;
        BasketballSounds.enabled = sounds;
        if (sounds) PlayerPrefs.SetInt("sounds",1);
        else PlayerPrefs.SetInt("sounds",0);
    }
}
