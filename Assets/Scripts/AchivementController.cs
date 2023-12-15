using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchivementController : MonoBehaviour
{ 
    [SerializeField] private List<Achive> achivments;
    [SerializeField] private GameObject template;
    [SerializeField] private Transform panelTransform;
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
    public void Start()
    {
        for (int i = 0; i < achivments.Count; i++)
        {
            GameObject achivegm= Instantiate(template,panelTransform);
            AchiveItem achiveItem = achivegm.GetComponent<AchiveItem>();
            if (achivments[i].type == TypeOfAchievements.points)
            {
                if (PlayerPrefs.GetInt("Score") > achivments[i].value)
                {
                    achivments[i].isCompleted = true;
                }
            }
            if (achivments[i].type == TypeOfAchievements.finishgame)
            {
                if (PlayerPrefs.GetInt("OnlyUp", 0) == 1) achivments[i].isCompleted = true;
            }
            achiveItem.image.enabled = achivments[i].isCompleted;
            achiveItem.text.text = achivments[i].text;
        }
    }
    
}
public enum TypeOfAchievements
{
    points,
    finishgame
}
[Serializable]
public class Achive
{
    public string text;
    public int value;
    public bool isCompleted;
    public TypeOfAchievements type;
}
