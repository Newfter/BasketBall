using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private AudioSource button;
    public void LoadLevel()
    {
        SceneManager.LoadScene("Scenes/Level 1");
        button.Play();
    }
    
    public void LoadAchive()
    {
        SceneManager.LoadScene("Scenes/Achivments");
        button.Play();
    }
    
    public void LoadSettings()
    {
        SceneManager.LoadScene("Scenes/Setings");
        button.Play();
    }
    public void LoadOnlyUp()
    {
        SceneManager.LoadScene("Scenes/OnlyUp");
        button.Play();
    }
}
