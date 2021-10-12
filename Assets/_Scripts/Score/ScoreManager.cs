using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text wordHuntText, nameText, matchingText, spellingText;
    public PlayerPrefsManager playerPrefsManager;
    public GameObject clouds;

    GameObject preCursor;

    public Animator anim;

    void Start()
    {
        preCursor = GameObject.FindGameObjectsWithTag("main_music")[0].gameObject;
        wordHuntText.text = playerPrefsManager.WordHuntScore();
        nameText.text = playerPrefsManager.NameScore();
        matchingText.text = playerPrefsManager.MatchingScore();
        spellingText.text = playerPrefsManager.SpellingScore();
        anim.Play("CloudTrans2");
        Invoke("DisableClouds", 1.0f);
    }

    public void ClearScores()
    {
        playerPrefsManager.ClearScores();
        PlaceScoresOnBoard();
    }

    void PlaceScoresOnBoard()
    {
        wordHuntText.text = playerPrefsManager.WordHuntScore();
        nameText.text = playerPrefsManager.NameScore();
        matchingText.text = playerPrefsManager.MatchingScore();
        spellingText.text = playerPrefsManager.SpellingScore();
    }

    void DisableClouds()
    {
        clouds.SetActive(false);
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void BackButton()
    {
        if (preCursor.GetComponent<MainMusicTheme>().hasGoneToMainMenu)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene("0_TitleScene");
        }
    }
}
