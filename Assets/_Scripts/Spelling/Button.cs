using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isTheCorrectAns;
    public GameObject thisQuestion, nextQuestion;
    public Stars stars;
    public bool isLastQuestion = false;

    bool isDeactivating = false;
    GameObject gameManagerScript;
    SpellingGameManager gameManager;
    GameObject parentGameObject;

    private void Start()
    {
        parentGameObject = this.transform.parent.gameObject;

        gameManagerScript = GameObject.Find("SpellingGameManager");
        gameManager = gameManagerScript.GetComponent<SpellingGameManager>();
    }

    private void OnMouseDown()
    {
        if (stars.score < 10 && !gameManager.gameEnded && !gameManager.pauseGame && parentGameObject.GetComponent<PlayAudio>().isDeactivating == false)
        {
            if (isTheCorrectAns)
            {
                parentGameObject.GetComponent<PlayAudio>().isDeactivating = true;
                isDeactivating = true;
                gameManager.PlayCorrectSound();
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
            {   parentGameObject.GetComponent<PlayAudio>().isDeactivating = true;
                isDeactivating = true;
                gameManager.PlayWrongSound();
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
        gameManager.ShowTextThenTurnOffAfter2Secs();
        Invoke("DeactivateAfterTwoSecs", 2.0f);
    }

    public void DeactivateAfterTwoSecs()
    {
        thisQuestion.SetActive(false);
        nextQuestion.SetActive(true);
    }
}
