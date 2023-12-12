using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitToMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}