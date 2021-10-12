using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScriptManager : MonoBehaviour
{
    public AudioSource buttonSound;
    public GameObject instructionPanel;
    public GameObject miniGamesPanel;
    public GameObject instructionsPanel;
    public Text star1, star2, star3, star4;
    public Animator anim;
    public Animator quitAppAnim;
    public GameObject quitAppPanel;

    GameObject preCursor;
    bool isQuitting = false;
    bool isTransitioning = false;
    GameObject mainGameMusic;

    private void Start()
    {
        preCursor = GameObject.FindGameObjectsWithTag("main_music")[0].gameObject;
        preCursor.GetComponent<MainMusicTheme>().hasGoneToMainMenu = true;
        mainGameMusic = GameObject.FindGameObjectWithTag("main_music");

        if (mainGameMusic != null)
        {
            AudioSource mainMusicAS = mainGameMusic.GetComponent<AudioSource>();
            mainMusicAS.volume = 1f;
        }

        if (PlayerPrefs.HasKey("PLAYED"))
        {
            DisableInstructionPanel();
        }

        if (!PlayerPrefs.HasKey("MATCHINGCOLORSSTARS"))
        {
            star1.text = "";
        }
        else
        {
            if (PlayerPrefs.GetInt("MATCHINGCOLORSSTARS") == 0)
            {
                star1.text = "";
            }

            if (PlayerPrefs.GetInt("MATCHINGCOLORSSTARS") == 1)
            {
                star1.text = "5";
            }

            if (PlayerPrefs.GetInt("MATCHINGCOLORSSTARS") == 2)
            {
                star1.text = "55";
            }

            if (PlayerPrefs.GetInt("MATCHINGCOLORSSTARS") == 3)
            {
                star1.text = "555";
            }

            if (PlayerPrefs.GetInt("MATCHINGCOLORSSTARS") == 4)
            {
                star1.text = "5555";
            }
            if (PlayerPrefs.GetInt("MATCHINGCOLORSSTARS") == 5)
            {
                star1.text = "55555";
            }
        }

        if (!PlayerPrefs.HasKey("NAMESTARS"))
        {
            star2.text = "";
        }
        else
        {
            if(PlayerPrefs.GetInt("NAMESTARS") == 0)
            {
                star2.text = "";
            }

            if (PlayerPrefs.GetInt("NAMESTARS") == 1)
            {
                star2.text = "5";
            }

            if (PlayerPrefs.GetInt("NAMESTARS") == 2)
            {
                star2.text = "55";
            }

            if (PlayerPrefs.GetInt("NAMESTARS") == 3)
            {
                star2.text = "555";
            }

            if (PlayerPrefs.GetInt("NAMESTARS") == 4)
            {
                star2.text = "5555";
            }
            if (PlayerPrefs.GetInt("NAMESTARS") == 5)
            {
                star2.text = "55555";
            }
        }

        if (!PlayerPrefs.HasKey("SPELLINGSTARS"))
        {
            star3.text = "";
        }

        if(!PlayerPrefs.HasKey("WHATSTHEDIFFERENCESTARS"))
        {
            star4.text = "";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitAppSeq();
    }

    public void QuitAppSeq()
    {
        isQuitting = true;
        quitAppPanel.SetActive(true);
        quitAppAnim.Play("QuitAppPanelAnim");
    }

    public void UnQuit()
    {
        isQuitting = false;
        quitAppPanel.SetActive(false);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void DisableInstructionPanel()
    {
        instructionPanel.SetActive(false);
        miniGamesPanel.SetActive(true);
    }

    public void GoToScene(string theScene)
    {
        if (!isQuitting)
        {
            SceneManager.LoadScene(theScene);
        }
    }

    public void GoToHighScore()
    {
        if (!isQuitting)
        {
            anim.Play("CloudTrans");
            Invoke("GoToScoreScene", 1.2f);
        }
    }

    public void GoToScoreScene()
    {
        if (!isQuitting)
        {
            if (!isTransitioning)
            {
                SceneManager.LoadScene("Score");
            }
            else
            {
                return;
            }
        }        
    }

    public void ClickSound()
    {
        buttonSound.Play();
    }


}
