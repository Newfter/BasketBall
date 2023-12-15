using System.Globalization;
using TMPro;
using UnityEngine;

public class Hight : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hight;

    private BallController _ball;
    private float _h;

    private void Start()
    {
        hight.text = _h.ToString(CultureInfo.InvariantCulture);
        _ball = FindObjectOfType<BallController>();
        hight.text = "0";
        _h = _ball.basket.transform.position.y;
    }
}