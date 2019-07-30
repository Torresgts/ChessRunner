using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public float velocityEaseMusic;
    private float cachedVolume;
    public AudioClip mainMenuMusic;
    public AudioClip GameplayMusic;

    private AudioSource audioSource;

    public bool changeTheMusic;


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        cachedVolume = audioSource.volume;
        audioSource.volume=0;
        audioSource.Play();
        StartPlayMusic();
    }

    private void Update()
    {
        if(changeTheMusic)
        {
            ChangeMusic();
            changeTheMusic = false;
        }
    }

    private void StartPlayMusic()
    {
        StartCoroutine(EaseStartMusic());
    }

    public void ChangeMusic()
    {
        StartCoroutine(EaseChangeMusic());
    }

    private void StopMusic()
    {

    }

    IEnumerator EaseStartMusic()
    {
        while(audioSource.volume < cachedVolume)
        {
            yield return null;
            audioSource.volume+= Time.deltaTime * velocityEaseMusic;
        }
    }

    IEnumerator EaseChangeMusic()
    {
        
        while(audioSource.volume > 0.01f)
        {
            yield return null;
            audioSource.volume-= Time.deltaTime * velocityEaseMusic;
        }

        ChangeClip();
        audioSource.Play();
        
        while(audioSource.volume < cachedVolume)
        {
            yield return null;
            audioSource.volume+= Time.deltaTime * velocityEaseMusic;
        }

    }

    private void ChangeClip()
    {
        if(audioSource.clip.Equals(mainMenuMusic))
        {
            audioSource.clip = GameplayMusic;
        } else {
            audioSource.clip = mainMenuMusic;
        }
    }
}
