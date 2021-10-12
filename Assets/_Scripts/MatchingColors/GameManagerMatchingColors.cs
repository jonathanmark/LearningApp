using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerMatchingColors : MonoBehaviour
{
    public GameObject startInstructions, startInstructionsBg;
    public GameObject mainGame;
    public GameObject stars;
    public GameObject pauseButton;
    public GameObject gameMusic;
    public GameObject ps_Confetti;
    public GameObject pausePanel;
    public GameObject returnToMainMenuButton, showScorePanel;
    public AudioSource popSound, correctSound, wrongSound;
    public AudioSource buttonPressSound;

    public bool gameEnded;
    public bool pauseGame;

    GameObject mainGameMusic;

    //Memory save
    GameObject playerPrefsObj;
    PlayerPrefsManager playerPrefsManager;


    private void Start()
    {
        pauseGame = false;
        gameEnded = false;
        mainGameMusic = GameObject.FindGameObjectWithTag("main_music");

        //Memory save
        playerPrefsObj = GameObject.Find("PlayerPrefsObj");
        playerPrefsManager = playerPrefsObj.GetComponent<PlayerPrefsManager>();

        if (mainGameMusic != null)
        {
            AudioSource mainMusicAS = mainGameMusic.GetComponent<AudioSource>();
            mainMusicAS.volume = 0f;
        }
        gameMusic.SetActive(true);
        
    }

    public void StartGame()
    {
        startInstructions.SetActive(false);
        startInstructionsBg.SetActive(false);
        pauseButton.SetActive(true);
        mainGame.SetActive(true);
        stars.SetActive(true);
        buttonPressSound.Play();
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            Debug.Log("End Game");
            gameEnded = true;
            ps_Confetti.SetActive(true);
            InvokeRepeating("PlayPopSound", 0.0f, 2.0f);
            Invoke("ShowScore", 7.0f);

            //Add this line for memory
            playerPrefsManager.AddScoreToMemory("PLAYERPREFS_MATCHINGSHAPES", stars.GetComponent<Stars>());
        }
    }

    public void PlayPopSound()
    {
        popSound.Play();
    }

    public void ShowScore()
    {
        pauseButton.SetActive(false);
        mainGame.SetActive(false);
        CancelInvoke();
        showScorePanel.SetActive(true);
        ps_Confetti.SetActive(false);
        returnToMainMenuButton.SetActive(true);
        stars.SetActive(false);
    }

    public void PlayCorrectSound()
    {
        correctSound.Play();
    }

    public void PlayWrongSound()
    {
        wrongSound.Play();
    }

    public void ButtonPressSound()
    {
        buttonPressSound.Play();
    }

    public void PauseUnpauseGame()
    {
        buttonPressSound.Play();

        if (pauseGame)
        {
            pauseGame = false;
        }
        else
        {
            pauseGame = true;
        }

        if (pauseButton.activeInHierarchy)
        {
            pauseButton.SetActive(false);
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
            pauseButton.SetActive(true);
        }

        if(Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

        Debug.Log(Time.timeScale);
    }

    public void MuteSounds()
    {
        AudioSource miniGameMusic = gameMusic.GetComponent<AudioSource>();
        miniGameMusic.volume = 0.0f;
        popSound.volume = 0.0f;
        correctSound.volume = 0.0f;
        wrongSound.volume = 0.0f;
        buttonPressSound.volume = 0.0f;
    }

    public void UnmuteSounds()
    {
        AudioSource miniGameMusic = gameMusic.GetComponent<AudioSource>();
        miniGameMusic.volume = 1.0f;
        popSound.volume = 1.0f;
        correctSound.volume = 1.0f;
        wrongSound.volume = 1.0f;
        buttonPressSound.volume = 1.0f;
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
