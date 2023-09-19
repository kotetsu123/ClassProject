using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_Manager : MonoBehaviour
{
    public static Music_Manager instance;
    public Toggle musicToggle;
    private const string MusicToggleKey = "MusicToggle";
    private AudioSource audioSource;
    //public bool isClicking = false;
    public bool isClicking = true;//Ĭ�����ֿ���
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LoadMusicEnabledState();
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

    public void ToggleMusic(/*bool enabled*/)
    {
        isClicking = !isClicking;
        if (isClicking)//!isClicking)
        {
            audioSource.Play();
            //isClicking = true;
        }
        else
        {
            audioSource.Stop();
           // isClicking = false;
        }
        SaveMusicEnabledState();
    }

    private void SaveMusicEnabledState()
    {
        int musicEnabledValue = isClicking ? 1 : 0;
        PlayerPrefs.SetInt(MusicToggleKey, musicEnabledValue);
        PlayerPrefs.Save();
    }
    private void LoadMusicEnabledState()
    {
        int musicEnabledValue = PlayerPrefs.GetInt(MusicToggleKey, 1);//Ĭ�Ͽ���
        isClicking = (musicEnabledValue == 1);
        //���ݼ��ص�״̬����Toggle���
        musicToggle.isOn = isClicking;
        if (isClicking)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
