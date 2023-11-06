using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.GetChild(0).Rotate(0.0f, 0.0f, 10.0f, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hp = collision.GetComponent<Health>();
        var enemy = collision.GetComponent<Enemy>();

        if (hp != null && enemy != null)
        {
            // reduce health
            hp.DealDamage(damage);
            // so that projectile doesn't kill everything on its path
            Destroy(gameObject);
        }
    }
}
