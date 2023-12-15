using TMPro;
using UnityEngine;
public class Hight : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hight;

    private BallController _ball;
    private int _h;
    private void Start() {_ball = FindObjectOfType<BallController>();}
    private void Update()
    {
        _h = (int)_ball.transform.position.y - 34;
        hight.text = _h.ToString();
    }
}