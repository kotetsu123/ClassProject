using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour
{
    public static Music_Manager instance;
    private const string MusicToggleKey = "MusicToggle";
    private AudioSource audioSource;
    public bool isClicking = false;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    IsMusicEnabled();
    //}
    //public void ToggleMusic()
    //{
    //    bool musicEnabled = !IsMusicEnabled();
        
    //}
    //public bool IsMusicEnabled()
    //{
    //    return audioSource.isPlaying;
    //}

    public void SetMusicEnabled(/*bool enabled*/)
    {
        if (!isClicking)
        {
            audioSource.Play();
            isClicking = true;
        }
        else
        {
            audioSource.Stop();
            isClicking = false;
        }
        int musicEnabledValue = isClicking ? 1 : 0;
        PlayerPrefs.SetInt(MusicToggleKey, musicEnabledValue);
        PlayerPrefs.Save();
    }
}
