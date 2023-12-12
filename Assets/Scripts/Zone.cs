using UnityEngine;

public class Zone : MonoBehaviour
{
    public Transform net1, net2;
    public float minX, maxX, minY, maxY;
    
    [SerializeField] private GameObject trap;
    [SerializeField] private Transform map;

    public void IncreaseNets()
    {
        net1.localScale = net1.localScale * 1.5f;
        net2.localScale = net2.localScale * 1.5f;
    }
    public void DecreaseNets()
    {
        net1.localScale = net1.localScale * 0.75f;
        net2.localScale = net2.localScale * 0.75f;
    }

    public void MoveRings()
    {
        do
        {
            net1.localPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
            net2.localPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
        } while (Vector3.Distance(net1.position, net2.position) < 5);
    }

    public void OnTrap()
    {
        GameObject newTrap =  Instantiate(trap, map);
        newTrap.transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Destroy(newTrap,20);
    }
}
