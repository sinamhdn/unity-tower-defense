using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;

        if (target.GetComponent<Thombstone>())
        {
            GetComponent<Animator>().SetTrigger("Jump");
            return;
        }

        if (target.GetComponent<Protector>())
        {
            GetComponent<Enemy>().Attack(target);
            return;
        }
    }
}
