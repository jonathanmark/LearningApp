using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicTheme : MonoBehaviour
{
    public bool hasGoneToMainMenu = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("main_music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }



}

