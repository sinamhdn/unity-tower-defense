using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<HPDisplay>().TakeLife();
        Destroy(collision.gameObject);
    }
}
