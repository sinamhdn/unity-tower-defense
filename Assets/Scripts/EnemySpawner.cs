using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Enemy[] enemyPrefabArray;

    bool spawn = true;

    // Start is called before the first frame update (converted to coroutine)
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }
    }

    private void Update()
    {
        if (GameSession.levelFinished)
        {
            this.transform.parent.gameObject.SetActive(false);
            StopSpawn();
        }
    }

    private void SpawnEnemy()
    {
        var enemyIndex = Random.Range(0, enemyPrefabArray.Length);
        if (!enemyPrefabArray[enemyIndex]) return;
        Spawn(enemyPrefabArray[enemyIndex]);
    }

    private void Spawn(Enemy enemy)
    {
        Enemy newEnemy = Instantiate(enemy, transform.position, transform.rotation) as Enemy;
        // do this so the attackers instantiate as child of the spawner
        newEnemy.transform.parent = transform;
    }

    public void StopSpawn()
    {
        spawn = false;
    }
}
