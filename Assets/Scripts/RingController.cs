using UnityEngine;

public class RingController : MonoBehaviour
{
    public int score;
    [SerializeField] private AudioSource scoreAudioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        scoreAudioSource.Play();
    }
}
