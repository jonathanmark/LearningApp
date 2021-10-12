using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReader : MonoBehaviour
{
    public Sprite sixStar, eightStar, tenStar;
    public GameObject scoreFeedbackImage;
    public Stars starsScript;

    void Awake()
    {

        Debug.Log("Got Score:" + starsScript.GetScore());
        SpriteRenderer sr = scoreFeedbackImage.GetComponent<SpriteRenderer>();
        if(starsScript.GetScore() <= 6)
        {
            Debug.Log("dumbass");
            sr.sprite = sixStar;
        }
        else if (starsScript.GetScore() > 6 && starsScript.GetScore() < 8)
        {
            Debug.Log("Good");
            sr.sprite = eightStar;
        }
        else if (starsScript.GetScore() >= 8 && starsScript.GetScore() == 10)
        {
            Debug.Log("nice");
            sr.sprite = tenStar;
        }

    }
}
