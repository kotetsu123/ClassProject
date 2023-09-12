using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicText_Controler : MonoBehaviour
{
    public Text soundText;
    private bool IsMusicEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
      //  UpdateSoundText();
    }

    // Update is called once per frame
    void Update()
    {
      //  UpdateSoundText();

    }
    public void ToggleMusic()
    {

        //IsMusicEnabled = IsMusicEnabled;
        //UpdateSoundText();
       
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
