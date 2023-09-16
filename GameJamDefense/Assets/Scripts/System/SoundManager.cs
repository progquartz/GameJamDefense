using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource[] audios;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>();
    }


    public void PlayPlatformBreak()
    {
        audios[0].Play();
    }

    public void PlayEnemyDeath()
    {
        audios[1].Play();
    }

    public void PlayButtonClick()
    {
        audios[2].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
