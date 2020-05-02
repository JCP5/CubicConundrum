using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ambience : MonoBehaviour
{
    public static Ambience ambience;
    public AudioClip[] audioClips;
    AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (ambience != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            ambience = this;
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        audioSource = this.GetComponent<AudioSource>();
        CheckScene(SceneManager.GetActiveScene());
    }

    void OnSceneLoad(Scene s, LoadSceneMode mode)
    {
        CheckScene(s);
    }

    void CheckScene(Scene s)
    {
        if (s.buildIndex == 0 || s.buildIndex == 61 || s.buildIndex == 62)
        {
            if (audioSource.clip != audioClips[0])
            {
                audioSource.Stop();
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.clip != audioClips[1])
            {
                audioSource.Stop();
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }
        }
    }
}
