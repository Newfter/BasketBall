using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
public class BallController : MonoBehaviour
{
    public GameObject button1, button2, button3, panel, panel2, ttext, trap, finishtext;
    public int level;
    public TextMeshProUGUI timerText;
    [SerializeField] private int jumpPower, speed, score, highScore;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    [SerializeField] private Transform overlapPosition;
    [SerializeField] private float overlapRadius;
    [SerializeField] private LayerMask overlapLayerMask;
    [SerializeField] private AudioSource bounceAudioSource, superAudioSource, loosingAudioSource, audiofinish;
    private Rigidbody2D rb;
    private bool enableJump, dubleJump;
    private int lastMilestone;
    private GameManager gm;
    [SerializeField] private List<Zone> zones;
    private void Start()
    {
        finishtext.SetActive(false);
        panel2.SetActive(false);
        button3.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        panel.SetActive(false);
        ttext.SetActive(false);
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        scoreText.text = "0";
        dubleJump = true;
        score = 0;
        lastMilestone = 0;
        level = 0;
    }
    public void Left() {print("pelmen");rb.AddForce(Vector3.left * speed);}
    public void Right(){rb.AddForce(Vector3.right * speed);}
    public void Jump()
    {
        if (enableJump)
        {
            enableJump = false;
            rb.AddForce(Vector3.up * jumpPower);
        }
        else if (!enableJump && dubleJump)
        {
            dubleJump = false;
            rb.AddForce(Vector3.up * jumpPower);
        }
    }
    public void Contineu(){panel2.SetActive(false);}
    public void Rastart(){Application.LoadLevel(Application.loadedLevel);}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) rb.AddForce(Vector3.left * speed);
        if (Input.GetKeyDown(KeyCode.D)) rb.AddForce(Vector3.right * speed);
        if (Input.GetKeyDown(KeyCode.K)) SetScore(100);
        if (Input.GetKeyDown(KeyCode.L)) StartCoroutine(gm.Spawn(zones[level]));
        if (Input.GetKeyDown(KeyCode.P)) zones[level].MoveRings();
        var col = Physics2D.OverlapCircleAll(overlapPosition.position, overlapRadius, overlapLayerMask);
        enableJump = false;
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].gameObject.CompareTag("Ground"))
            {
                enableJump = true;
                dubleJump = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enableJump)
            {
                enableJump = false;
                rb.AddForce(Vector3.up * jumpPower);
            }
            else if (!enableJump && dubleJump)
            {
                dubleJump = false;
                rb.AddForce(Vector3.up * jumpPower);
            }
        }
        if (transform.position.y < -100) ;
    }
    private IEnumerator TimerSize()
    {
        transform.localScale = transform.localScale * 2;
        overlapRadius = overlapRadius * 1.5f;
        panel.SetActive(true);
        for (int i = 15; i > 0; i--)
        {
            timerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        panel.SetActive(false);
        transform.localScale = transform.localScale * 0.5f;
        overlapRadius = overlapRadius * 0.75f;
    }
    private IEnumerator TimerNets()
    {
        zones[level].IncreaseNets();
        panel.SetActive(true);
        for (int i = 15; i > 0; i--)
        {
            timerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        panel.SetActive(false);
        zones[level].DecreaseNets();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))panel2.SetActive(true);
        if (other.gameObject.CompareTag("Score"))
        {
            RingController ring = other.gameObject.GetComponent<RingController>();
            SetScore(ring.score);
        }
        if (other.gameObject.CompareTag("Bonus"))
        {
            Bonus b = other.gameObject.GetComponent<Bonus>();
            print(b.type.ToString());
            if (b.type == TypeOfBonus.Size) StartCoroutine(TimerSize());
            if (b.type == TypeOfBonus.Nets) StartCoroutine(TimerNets());
            if (b.type == TypeOfBonus.Score) SetScore(b.value);
            StartCoroutine(gm.Spawn(zones[level]));
            Destroy(other.gameObject);
        }
    }
    private void SetScore(int scoreInt)
    {
        score += scoreInt;
        scoreText.text = score.ToString();
        CheckEvent();
        if (score > PlayerPrefs.GetInt("HighScore", 0)) PlayerPrefs.SetInt("HighScore", score);
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        if (score >= 100 && level == 0) button1.SetActive(true);
        if (score >= 500 && level == 1) button2.SetActive(true);
        if (score >= 1000 && level == 2) button3.SetActive(true);
    }
    private void CheckEvent()
    {
        if (score >= lastMilestone + 10)
        {
            lastMilestone = lastMilestone + 10;
            zones[level].MoveRings();
            zones[level].OnTrap();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            PlayerPrefs.SetInt("OnlyUp", 1); 
            finishtext.SetActive(true);
            audiofinish.Play();
            Destroy(finishtext, 3);
            
        }
        bounceAudioSource.Play();
    }
    private void OnDrawGizmos(){Gizmos.DrawSphere(overlapPosition.position, overlapRadius);}
}