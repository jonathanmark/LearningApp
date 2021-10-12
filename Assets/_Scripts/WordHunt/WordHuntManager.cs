using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class WordHuntManager : MonoBehaviour
{
    public string[] words = { "BALL", "HAT", "SOFA", "DOG", "MILK", "BAG", "TOY", "DRESS", "BUS", "APPLE" };
    private string[] alphabetArray = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",};
    string[] b1 = { "B", "A", "L", "L", "N", "B", "O", "V", "S", "R", "E", "I", "W", "Q", "K", "L" };
    string[] b2 = { "D", "N", "L", "O", "H", "A", "T", "V", "S", "U", "Q", "F", "W", "N", "K", "Z" };
    string[] b3 = { "L", "K", "A", "U", "T", "X", "J", "V", "S", "O", "F", "A", "W", "N", "P", "Y" };
    string[] b4 = { "B", "A", "R", "L", "U", "K", "O", "X", "S", "J", "M", "I", "R", "D", "O", "G" };
    string[] b5 = { "V", "C", "Z", "K", "B", "U", "R", "L", "S", "R", "E", "I", "X", "J", "K", "M" };
    string[] b6 = { "V", "L", "O", "G", "N", "T", "Y", "P", "X", "B", "A", "G", "Z", "I", "P", "M" };
    string[] b7 = { "B", "A", "D", "K", "O", "G", "Q", "T", "D", "V", "E", "O", "U", "Q", "X", "Y" };
    string[] b8 = { "D", "R", "E", "S", "T", "E", "N", "S", "S", "R", "E", "I", "W", "Y", "D", "L" };
    string[] b9 = { "D", "Z", "L", "M", "N", "W", "B", "V", "O", "E", "U", "I", "W", "B", "S", "L" };
    string[] b10= { "E", "V", "O", "L", "S", "N", "A", "V", "Q", "T", "O", "E", "A", "P", "P", "L" };
    GameObject mainGameMusic;

    public Sprite[] alphabetSprites;
    public GameObject question1, question2, question3, question4, question5, question6, question7, question8, question9, question10;
    public GameObject instructionsUI, maingameGroup, pauseButton, pausePanel;
    public Animator anim;
    public AudioSource correctSoundEffect, buttonPressSound, popSound;
    public BoardManager boardManager;

    public GameObject boardGameObject, backGroundIntro, stars, endScore, gameMusic, ps_Confetti, showScorePanel, returnToMainMenuButton;

    public int levelNumber = 0;
    public bool pauseGame, gameEnded;

    //Memory save
    GameObject playerPrefsObj;
    PlayerPrefsManager playerPrefsManager;

    private void Start()
    {
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

    public void StartMiniGame()
    {
        pauseButton.SetActive(true);
        boardGameObject.SetActive(true);
        instructionsUI.SetActive(false);
        maingameGroup.SetActive(true);
        backGroundIntro.SetActive(false);
        stars.SetActive(true);
    }

    public void QuestionDone()
    {
        if (levelNumber <= 9)
        {
            IncreaseStars();
            anim.Play("NewQuestionBoard");
            correctSoundEffect.Play();
            Invoke("ChangeQuestion", 0.25f);
        }
        else
        {
            IncreaseStars();
            return;
        }
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            Debug.Log("End Game");
            gameEnded = true;
            ps_Confetti.SetActive(true);
            InvokeRepeating("PlayPopSound", 0.0f, 2.0f);
            //Add this line for memory
            playerPrefsManager.AddScoreToMemory("PLAYERPREFS_WORDHUNT", stars.GetComponent<Stars>());
            Invoke("ShowScore", 7.0f);
        }
    }

    public void PlayPopSound()
    {
        popSound.Play();
    }

    public void ShowScore()
    {
        question10.SetActive(false);
        boardGameObject.SetActive(false);
        pauseButton.SetActive(false);
        maingameGroup.SetActive(false);
        CancelInvoke();
        showScorePanel.SetActive(true);
        ps_Confetti.SetActive(false);
        returnToMainMenuButton.SetActive(true);
        stars.SetActive(false);
    }

    public void IncreaseStars()
    {
        stars.GetComponent<Stars>().IncreaseScore();
    }

    public void ChangeQuestion()
    {
        levelNumber++;
        if (levelNumber <= 9)
        {
            boardManager.NewQuestion();
            NewPictureGuide();
        }
        else
        {
            EndGame();
        }
    }

    public void NewPictureGuide()
    {
        if (levelNumber == 1)
        {
            question1.SetActive(false);
            question2.SetActive(true);
        }

        if (levelNumber == 2)
        {
            question2.SetActive(false);
            question3.SetActive(true);
        }

        if (levelNumber == 3)
        {
            question3.SetActive(false);
            question4.SetActive(true);
        }

        if (levelNumber == 4)
        {
            question4.SetActive(false);
            question5.SetActive(true);
        }

        if (levelNumber == 5)
        {
            question5.SetActive(false);
            question6.SetActive(true);
        }

        if (levelNumber == 6)
        {
            question6.SetActive(false);
            question7.SetActive(true);
        }

        if (levelNumber == 7)
        {
            question7.SetActive(false);
            question8.SetActive(true);
        }

        if (levelNumber == 8)
        {
            question8.SetActive(false);
            question9.SetActive(true);
        }

        if (levelNumber == 9)
        {
            question9.SetActive(false);
            question10.SetActive(true);
        }
    }

    public Sprite ButtonLetterSprite(int numInBoard)
    {
        string[] theBoard = BoardPieces();
        string toFind = theBoard[numInBoard];
        int spriteIndexToSend = 0;
        foreach (string x in alphabetArray)
        {
            if (x == toFind)
            {
                break;
            }
            spriteIndexToSend++;
        }
        return alphabetSprites[spriteIndexToSend];
    }

    public char ButtonLetter(int numInBoard)
    {
        string[] theBoard = BoardPieces();
        string toFind = theBoard[numInBoard];
        int indexToSend = 0;
        foreach (string x in alphabetArray)
        {
            if (x.Equals(toFind))
            {
                break;
            }
            indexToSend++;
        }
        return Convert.ToChar(alphabetArray[indexToSend]);
    }

    public string CurrentWord()
    {
        return words[levelNumber];
    }

    public string[] BoardPieces()
    {
        if (levelNumber == 0)
        {
            return b1;
        }

        if (levelNumber == 1)
        {
            return b2;
        }

        if (levelNumber == 2)
        {
            return b3;
        }

        if (levelNumber == 3)
        {
            return b4;
        }

        if (levelNumber == 4)
        {
            return b5;
        }

        if (levelNumber == 5)
        {
            return b6;
        }

        if (levelNumber == 6)
        {
            return b7;
        }

        if (levelNumber == 7)
        {
            return b8;
        }

        if (levelNumber == 8)
        {
            return b9;
        }

        if (levelNumber == 9)
        {
            return b10;
        }

        return null;
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

        if (Time.timeScale == 1.0f)
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
        correctSoundEffect.volume = 0.0f;
        buttonPressSound.volume = 0.0f;
    }

    public void UnmuteSounds()
    {
        AudioSource miniGameMusic = gameMusic.GetComponent<AudioSource>();
        miniGameMusic.volume = 1.0f;
        popSound.volume = 1.0f;
        correctSoundEffect.volume = 1.0f;
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
