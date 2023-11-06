using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float walkSpeed = 1f;
    GameObject currentTarget;
    float defaultWalkSpeed;

    // Awake is called when the object is instantiated but start is called before first frame is run
    // Animation events are called before Start function so we use Awake
    private void Awake()
    {
        defaultWalkSpeed = walkSpeed;

        FindObjectOfType<GameSession>().EnemySpawned();
    }

    private void OnDestroy()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (!gameSession) return;
        gameSession.EnemyDestroyed();
    }

    // Update is called once per frame
    private void Update()
    {
        // Time.deltaTime to make movement speed frame independent
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("Attack", false);
        }
    }

    // animation timeline event will call this function
    public void SetMovementSpeed(float speed)
    {
        walkSpeed = speed == 0f ? 0f : defaultWalkSpeed * speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("Attack", true);
        currentTarget = target;
    }

    public void HitTarget(float damage)
    {
        if (!currentTarget) return;
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
