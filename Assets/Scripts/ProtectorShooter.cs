using UnityEngine;

public class ProtectorShooter : MonoBehaviour
{
    const string PARENT_NAME = "Projectiles";
    // instead of using this shooter socket we get the child with GetChild()
    [SerializeField] GameObject projectile, shooter;
    EnemySpawner thisLaneSpawner;
    Animator animator;
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateParent();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnemyInLane())
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawners)
        {
            // Mathf.Epsilon because zeros in computers are not absolute
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                thisLaneSpawner = spawner;
            }
        }
    }

    private bool IsEnemyInLane()
    {
        if (!thisLaneSpawner) return false;
        if (thisLaneSpawner.transform.childCount <= 0)
            return false;
        return true;
    }

    public void ShooterFire()
    {
        if (projectile)
        {
            // if we dont use as GameObject it will only be an object and we wouldn't be able to instantiate it in the scene as a GameObject
            // Instantiate(projectile, shooter.transform.position, shooter.transform.rotation);
            GameObject newProjectile = Instantiate(projectile, transform.GetChild(0).GetChild(0).position, transform.GetChild(0).GetChild(0).rotation) as GameObject;
            newProjectile.transform.parent = parent.transform;
        }
    }

    private void CreateParent()
    {
        parent = GameObject.Find(PARENT_NAME);
        if (!parent)
        {
            parent = new GameObject(PARENT_NAME);
        }
    }
}
