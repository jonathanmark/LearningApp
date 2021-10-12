using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{

    public int score;
    public SpriteRenderer star1, star2, star3, star4, star5;
    public Sprite starFilled;

    private void Start()
    {
        score = 0;
    }

    public void IncreaseScore()
    {
        score++;
        UpdateStars();
    }

    public void UpdateStars()
    {
        if (score >= 2)
        {
            star1.sprite = starFilled;
            if (score >= 4)
            {
                star2.sprite = starFilled;
                if (score >= 6)
                {
                    star3.sprite = starFilled;
                    if (score >= 8)
                    {
                        star4.sprite = starFilled;
                        if (score == 10)
                        {
                            star5.sprite = starFilled;
                        }
                    }
                }
            }
        }

        Debug.Log(score);
    }

    public int GetScore()
    {
        return score;
    }

    public string GetScoreStr()
    {
        return score.ToString();
    }

}
