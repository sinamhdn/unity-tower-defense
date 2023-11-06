using TMPro;
using UnityEngine;

public class ProtectorButton : MonoBehaviour
{
    [SerializeField] Protector protectorPrefab;

    private void Start()
    {
        LabelBtnWithCost();
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<ProtectorButton>();
        foreach (ProtectorButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        if (!protectorPrefab) return;

        FindObjectOfType<ProtectorSpawner>().SetSelectedProtector(protectorPrefab);
    }

    private void LabelBtnWithCost()
    {
        TextMeshProUGUI costText = GetComponentInChildren<TextMeshProUGUI>();
        if (!costText) return;
        costText.text = protectorPrefab.GetResCost().ToString();
    }
}
