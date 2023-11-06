using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            return;
        }
        Debug.LogError("MASTER VOLUME IS OUT OF RANGE.");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);

    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
            return;
        }
        Debug.LogError("DIFFICULTY IS OUT OF RANGE.");
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetDefaultMasterVolume(float value)
    {
        if (!PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
    }

    public static void SetDefaultDifficulty(float value)
    {
        if (!PlayerPrefs.HasKey(DIFFICULTY_KEY)) PlayerPrefs.SetFloat(DIFFICULTY_KEY, value);
    }

    // Start is called before the first frame update
    // void Start()
    // { 
    // }
    // Update is called once per frame
    // void Update()
    // { 
    // }
}
