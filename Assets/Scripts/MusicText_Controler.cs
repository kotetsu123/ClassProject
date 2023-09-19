using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicText_Controler : MonoBehaviour
{
    public Text soundText;
    

    // Start is called before the first frame update
    void Start()
    {
         UpdateSoundText();
        /*if (PlayerPrefs.HasKey("MusicOn"))
        {
            int musicEnabledValue = PlayerPrefs.GetInt("MusicOn");
            if (musicEnabledValue == 1)
            {
                soundText.text = "Sound:On";
            }
            else
            {
                soundText.text = "Sound:Off";
            }
        }
        else
        {
            soundText.text = "Sound:Off";
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //  UpdateSoundText();

    }
    public void ToggleMusic()
    {

        Music_Manager.instance.ToggleMusic();
        UpdateSoundText();

    }


    public void UpdateSoundText()
    {

        if (Music_Manager.instance.isClicking)
        {
            soundText.text = "Sound:On";
        }
        else
        {
            soundText.text = "Sound:Off";
        }
    }

}
