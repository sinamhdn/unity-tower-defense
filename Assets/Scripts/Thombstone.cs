using UnityEngine;

public class Thombstone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        //if (enemy != null)
        //{

        //}
    }
}
