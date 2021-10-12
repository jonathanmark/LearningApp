using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices : MonoBehaviour
{
    public bool isTheCorrectAns;
    public GameObject thisQuestion, nextQuestion;
    public Stars stars;
    public bool isLastQuestion = false;

    GameObject gameManagerScript;
    NameGameManager gameManager;

    GameObject wrongSoundObject, correctSoundObject;
    AudioSource cSound, wSound;

    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManagerName");
        gameManager = gameManagerScript.GetComponent<NameGameManager>();
        wrongSoundObject = GameObject.Find("WrongSound");
        wSound = wrongSoundObject.GetComponent<AudioSource>();
        correctSoundObject = GameObject.Find("CorrectSound");
        cSound = correctSoundObject.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (stars.score < 10 && !gameManager.gameEnded && !gameManager.pauseGame)
        {
            if (isTheCorrectAns)
            {
                cSound.Play();
                if (!isLastQuestion)
                {
                    NextQuestion();
                    stars.IncreaseScore();

                }
                else
                {
                    stars.IncreaseScore();
                    gameManager.EndGame();
                }
            }
            else
            {
                wSound.Play();
                if (!isLastQuestion)
                {
                    NextQuestion();
                }
                else
                {
                    gameManager.EndGame();
                }

            }
        }

    }

    public void NextQuestion()
    {
        thisQuestion.SetActive(false);
        nextQuestion.SetActive(true);

    }
}
