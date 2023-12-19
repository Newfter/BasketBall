using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UISettingsMusic : MonoBehaviour
    {
        [SerializeField] private Toggle toggleMusic, toogleSounds;

        private void Start()
        {
            toggleMusic.isOn = PlayerPrefs.GetInt("music") == 1;
            toogleSounds.isOn = PlayerPrefs.GetInt("sounds") == 1;
        }

        public void EnebleToogleMusic()
        {
            Music.Instance.EnableMusic();
        }

        public void EnableToogleSounds()
        {
            
        }
    }
}