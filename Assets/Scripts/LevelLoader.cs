using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float timeToWait = 4f;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        LoadStartScene();
    }

    public void LoadStartScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0 || currentSceneIndex == 1 || currentSceneIndex == 2)
        {
            StartCoroutine(LoadStartSceneWait());
        }
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        // Debug.Log(GameSession.loseSceneBuildIndex);
        GameSession.levelFinished = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(GameSession.loseSceneBuildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadOptionsScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("OptionsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadStartSceneWait()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("StartScreen");
    }
}
