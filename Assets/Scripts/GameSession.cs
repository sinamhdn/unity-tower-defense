using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public static int loseSceneBuildIndex;
    public static bool levelFinished = false;
    [SerializeField] float waitTimeToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float resSpawnDelay = 3f;
    [SerializeField] int resSpawnValue = 25;
    int numberOfEnemies = 0;
    bool levelTimeEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        StartCoroutine(ResSpawn());
    }

    // Update is called once per frame
    // void Update()
    // {
    // }

    private void Awake()
    {
        GameSession.levelFinished = false;
    }

    private void StopSpawners()
    {
        EnemySpawner[] spawnerArray = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawnerArray)
        {
            spawner.StopSpawn();
        }
    }

    private void TidyupSceneAfterGameEnd()
    {
        levelFinished = true;

        Songbox songbox = FindObjectOfType<Songbox>();
        if (songbox) songbox.GetComponent<AudioSource>().Stop();


        // hide attackers when game lost
        Enemy[] enemyArray = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemyArray)
        {
            if (!enemy) continue;
            enemy.gameObject.SetActive(false);
        }

        // disable protectors
        Protector[] protectorArray = FindObjectsOfType<Protector>();
        foreach (Protector protector in protectorArray)
        {
            if (!protector) continue;
            protector.gameObject.SetActive(false);
        }

        // disable attacker spawners
        //EnemySpawner[] spawnerArray = FindObjectsOfType<EnemySpawner>();
        //foreach (EnemySpawner spawner in spawnerArray)
        //{
        //    if (!spawner) continue;
        //    spawner.gameObject.SetActive(false);
        //}
    }

    public void EnemySpawned()
    {
        numberOfEnemies++;
    }

    public void EnemyDestroyed()
    {
        numberOfEnemies--;
        if (numberOfEnemies <= 0 && levelTimeEnded)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerHasEnded()
    {
        levelTimeEnded = true;
        StopSpawners();
    }

    public void LevelLost()
    {
        StopSpawners();
        StartCoroutine(HandleLoseCondition());
    }

    IEnumerator HandleLoseCondition()
    {
        TidyupSceneAfterGameEnd();

        if (loseLabel) loseLabel?.SetActive(true);

        FindObjectOfType<GameTimer>().GetComponent<Animator>().speed = 0;

        // yield return new WaitForSecondsRealtime(waitTimeToLoad);
        yield return new WaitForSeconds(waitTimeToLoad);

        // if you set timescale to 0 before coroutine it wont work
        Time.timeScale = 0;

        // Debug.Log(SceneManager.GetActiveScene().buildIndex);
        // for this variable we use static variable to make it instance ndependent so unity wont reset this when scene loads
        // we use this variable to be able to replay the level that we lost on
        loseSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        FindObjectOfType<LevelLoader>().LoadLoseScene();
    }

    IEnumerator HandleWinCondition()
    {
        TidyupSceneAfterGameEnd();

        if (winLabel) winLabel?.SetActive(true);
        // winLabel.SetActive(true);

        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(waitTimeToLoad);

        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            FindObjectOfType<LevelLoader>().LoadWinScene();
        }
        else
        {
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }

    IEnumerator ResSpawn()
    {
        while (!levelFinished || !levelTimeEnded)
        {
            yield return new WaitForSeconds(resSpawnDelay);
            FindObjectOfType<ResourceDisplay>().AddRes(resSpawnValue);
        }
    }
}
