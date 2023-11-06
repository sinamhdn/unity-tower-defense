using TMPro;
using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] int resouce = 100;

    TextMeshProUGUI resText;

    // Start is called before the first frame update
    void Start()
    {
        resText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        resText.text = resouce.ToString();
    }

    public void AddRes(int amount)
    {
        resouce += amount;
        UpdateDisplay();
    }

    public void SpendRes(int amount)
    {
        if (resouce < amount) return;
        resouce -= amount;
        UpdateDisplay();
    }

    public bool HaveEnoughRes(int amount)
    {
        return resouce >= amount;
    }
}
