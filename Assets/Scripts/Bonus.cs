using UnityEngine;
public class Bonus : MonoBehaviour
{
    public TypeOfBonus type;
    public int value;
}
public enum TypeOfBonus
{
    Size,
    Nets,
    Score
}
