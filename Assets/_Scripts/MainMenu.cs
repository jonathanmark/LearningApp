using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource playButtonSound;

    public void LoadMainMenu()
    {
        playButtonSound.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadScorePage()
    {
        Animator anim = GameObject.Find("Canvas").transform.GetChild(3).GetComponent<Animator>();
        anim.Play("CloudTrans");
        playButtonSound.Play();
        Invoke("GoToScorePage", 1.0f);
    }

    void GoToScorePage() {
        SceneManager.LoadScene("Score");
    }
}
