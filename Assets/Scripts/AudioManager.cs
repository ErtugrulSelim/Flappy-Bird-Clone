using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton örneði
    public AudioSource musicSource; // Müzik için ses kaynaðý
    public AudioSource scoreSfx;
    public AudioSource gameOverSfx;
    public GameObject SoundPrefab;

    private const string SFXKey = "SFXLevel";
    private const string MusicKey = "MusicLevel";

    void Awake()
    {
        // Singleton örneði oluþtur
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(SoundPrefab);
        }
        else
        {
            Destroy(gameObject);
            Destroy(SoundPrefab.gameObject);
        }
    }

    void Start()
    {
        float savedVolumeofSFX = PlayerPrefs.GetFloat(SFXKey, 1f);
        float savedVolumeofMusic = PlayerPrefs.GetFloat(MusicKey, 1f);
        SetVolumeSFX(savedVolumeofSFX);
        SetVolumeMusic(savedVolumeofMusic);
    }

    public void SetVolumeSFX(float volume)
    {
        gameOverSfx.volume = volume;
        scoreSfx.volume = volume;
        PlayerPrefs.SetFloat(SFXKey, volume);
    }

    public void SetVolumeMusic(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(MusicKey, volume);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }


    public void PlayScoreSFX(AudioClip clip)
    {
        scoreSfx.PlayOneShot(clip);  
    }
    public void PlayGameOverSFX(AudioClip clip)
    {
        gameOverSfx.PlayOneShot(clip);
    }
}

