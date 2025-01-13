using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip mainMenuMusic;
    [SerializeField] AudioClip levelMusic;
    [SerializeField] AudioClip endGameMusic;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayBackgroundMusic(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBackgroundMusic(scene.name);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayBackgroundMusic(string sceneName)
    {
        AudioClip clipToPlay = null;

        // Determine which music to play based on the scene name
        if (sceneName == "MainMenu")
        {
            clipToPlay = mainMenuMusic;
        }
        else if (sceneName == "Level1" || sceneName == "Level2" || sceneName == "Level3")
        {
            clipToPlay = levelMusic;
        }
        else if (sceneName == "EndScene")
        {
            clipToPlay = endGameMusic;
        }

        // Play the selected clip if it's not already playing
        if (clipToPlay != null && musicSource.clip != clipToPlay)
        {
            musicSource.Stop();
            musicSource.clip = clipToPlay;
            musicSource.Play();
        }
        else if(!musicSource.isPlaying && clipToPlay != null)
        {
            // If no valid clip is found, stop playing music
            musicSource.Stop();
        }
    }
}
