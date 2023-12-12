using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> boosters;
    [SerializeField] private Transform startLocation2, startLocation3, startLocation4;
    [SerializeField] private AudioSource button;
    private BallController ball;

    private void Start()
    {
        ball = FindObjectOfType<BallController>();
    }

    public void StartSecondGameArena()
    {
        ball.basket.transform.position = startLocation2.position;
        Destroy(ball.button1);
        ball.level +=1;
    }
    public void StartThirdGameArena()
    {
        ball.basket.transform.position = startLocation3.position;
        Destroy(ball.button2);
        ball.level +=1;
    }
    public void StartFourthGameArea()
    {
        ball.basket.transform.position = startLocation4.position;
        Destroy(ball.button3);
        ball.level +=1;
    }

    public IEnumerator Spawn(Zone currentZone)
    {
        yield return new WaitForSeconds(Random.Range(10f, 15f));
        GameObject boosterGM = boosters[Random.Range(0,boosters.Count)];
        Instantiate(boosterGM);
        boosterGM.transform.position = new Vector3(Random.Range(currentZone.minX,currentZone.maxY),Random.Range(currentZone.minY,currentZone.maxY));
    }

    public IEnumerator Timer()
    {
        for (int i = 15; i > 0; i--)
        {
            ball.timerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
    }
}