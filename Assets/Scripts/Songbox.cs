using UnityEngine;

public class Songbox : MonoBehaviour
{
    AudioSource audioSource;
    public static Songbox songbox;

    private void Awake()
    {
        if (songbox)
            DestroyImmediate(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            songbox = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        // DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
