using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceScript : MonoBehaviour
{
    public bool isTheCorrectAns;
    public GameObject thisQuestion, nextQuestion;
    public Stars stars;
    public bool isLastQuestion = false;

    GameObject gameManagerScript;

    private void OnMouseDown()
    {
        gameManagerScript = GameObject.Find("MatchingColorsGameManager");
        GameManagerMatchingColors gameManager = gameManagerScript.GetComponent<GameManagerMatchingColors>();

        if (stars.score < 10 && !gameManager.gameEnded && !gameManager.pauseGame)
        {
            
            if (isTheCorrectAns)
            {
                gameManager.PlayCorrectSound();
                if (!isLastQuestion)
                {
                    nextQuestion.SetActive(true);
                    stars.IncreaseScore();
                    thisQuestion.SetActive(false);
                }
                else
                {
                    stars.IncreaseScore();
                    gameManager.EndGame();
                }
            }
            else
            {

                gameManager.PlayWrongSound();
                if (!isLastQuestion)
                {
                    nextQuestion.SetActive(true);
                    thisQuestion.SetActive(false);
                }
                else
                {
                    gameManager.EndGame();
                }

            }
        }
        
    }
}
