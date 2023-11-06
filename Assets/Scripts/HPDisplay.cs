using TMPro;
using UnityEngine;

public class HPDisplay : MonoBehaviour
{
    [SerializeField] float baseHP = 3f;
    [SerializeField] int damage = 1;
    TextMeshProUGUI hpText;
    float hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = baseHP - PlayerPrefsController.GetDifficulty();
        hpText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    // Update is called once per frame
    // void Update()
    // {
    // }

    private void UpdateDisplay()
    {
        hpText.text = hp.ToString();
    }

    public void TakeLife()
    {

        hp -= damage;
        UpdateDisplay();
        if (hp <= 0)
        {
            FindObjectOfType<GameSession>().LevelLost();
        }
    }
}
