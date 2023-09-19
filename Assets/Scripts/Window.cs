using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    private bool isPasuled = false;
    public Button continueGame;
    public Button newGame;
    public Button quitGame;
    public GameObject haveButtonPanel;
    public GameObject noButtonPanel;

    private static Window instance;
    public static Window Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        continueGame=GetComponent<Button>();   
        newGame=GetComponent<Button>();
        quitGame=GetComponent<Button>();
        //continueGame.onClick.AddListener(ButtonClick);
        haveButtonPanel.SetActive(false);
        noButtonPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ConsolePanle();
    }
    private void ConsolePanle()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*if (isPasuled)
            {
                ContinueGame();
            }*/

            /*else
            {
                FreezeTime();
            }*/
            if (!isPasuled)
            {
                FreezeTime();
            }
            else
            {
                ContinueGame();
            }
        }

    }
    public void FreezeTime()
    {
        Time.timeScale = 0.0f;
        isPasuled = true;
        Cursor.visible = true;
        haveButtonPanel.SetActive(true);
        noButtonPanel.SetActive(true);
        

    }
    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        isPasuled=false;
        Cursor.visible = false;
        haveButtonPanel.SetActive(false);
        noButtonPanel.SetActive(false);
    }
    private void ButtonClick()
    {
        Debug.Log("?");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
