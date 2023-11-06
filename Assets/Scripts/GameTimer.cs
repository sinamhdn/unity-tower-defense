using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // creates a tooltip when hover over in editor
    [Tooltip("Level Time in SECONDS")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) return;
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timeEnd = (Time.timeSinceLevelLoad >= levelTime);
        if (timeEnd || GameSession.levelFinished)
        {
            FindObjectOfType<GameSession>().LevelTimerHasEnded();
            triggeredLevelFinished = true;
        }
    }
}
