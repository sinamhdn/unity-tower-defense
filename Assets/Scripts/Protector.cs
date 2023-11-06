using UnityEngine;

public class Protector : MonoBehaviour
{
    [SerializeField] int cost = 100;

    public int GetResCost()
    {
        return (int)cost;
    }

    public void addRes(int amount)
    {
        FindObjectOfType<ResourceDisplay>().AddRes(amount);
    }
}
