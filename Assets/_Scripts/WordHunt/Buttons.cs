using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class Buttons : MonoBehaviour
{
    public Sprite buttonSpritePressed, buttonSpriteUnPressed;
    public AudioSource woodSound;
    public WordHuntManager wordHuntManager;
    public BoardManager boardManager;

    GameObject alphabetPictureObject;
    bool buttonIsDown = false;
    int numInBoard;
    char thisButtonLetter;

    private void Start()
    {
        GetAlphabet();
    }

    private void OnMouseDown()
    {
        if (buttonIsDown == false)
        {
            buttonIsDown = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = buttonSpritePressed;
            woodSound.Play();
            Vector3 pressPos = new Vector3(0.0f, -0.05f, -1.0f);
            alphabetPictureObject.transform.localPosition = pressPos;
            boardManager.AddLetter(thisButtonLetter);
        }
        else
        {
            buttonIsDown = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = buttonSpriteUnPressed;
            woodSound.Play();
            Vector3 regPos = new Vector3(0.0f, 0.00f, -1.0f);
            alphabetPictureObject.transform.localPosition = regPos;
            boardManager.RemoveLetter(thisButtonLetter);
        }
        
    }

    public void GetAlphabet()
    {
        
        //Get index number of piece in board by getting gameobject name and manip by regex
        numInBoard = Convert.ToInt32(Regex.Replace(transform.gameObject.name, "[^0-9]", "")) - 1;

        //Get alphabet pic object
        alphabetPictureObject = transform.GetChild(0).gameObject;

        //Get coresponding pic letter by sending index number
        Sprite letterSprite = wordHuntManager.ButtonLetterSprite(numInBoard);

        //Replace the alphabet by the retrieved picture
        alphabetPictureObject.GetComponent<SpriteRenderer>().sprite = letterSprite;

        thisButtonLetter = wordHuntManager.ButtonLetter(numInBoard);
    }

    public void ResetButton()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = buttonSpriteUnPressed;
        buttonIsDown = false;
        Vector3 regPos = new Vector3(0.0f, 0.00f, -1.0f);
        alphabetPictureObject.transform.localPosition = regPos;

    }

}
