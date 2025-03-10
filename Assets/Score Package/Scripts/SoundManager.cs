using UnityEngine;

// Nick - sound manager that manages.. sound, has a SFX and BGM function to allow both playing at the same time

public class SoundManager : MonoBehaviour
{

    #region Variables

    public static SoundManager instance; 

    public AudioSource bgMusicSource; // background audio

    public AudioSource sfxSource; // sound effect audio

    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip) // SFX
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayBGM(AudioClip clip) // BGM
    {
        bgMusicSource.clip = clip;
        bgMusicSource.Play();
    }
}