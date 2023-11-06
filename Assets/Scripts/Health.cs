using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float HP = 100f;
    [SerializeField] GameObject deathVFX;

    void TriggerDeathVFX()
    {
        if (!deathVFX) return;
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position + new Vector3(-1f, 0f, 0f), transform.rotation);
        Destroy(deathVFXObject, 1f);
    }

    public void DealDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }
}
