using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardManager : MonoBehaviour
{
    public List<GameObject> buttons;
    public WordHuntManager wordHuntManager;
    public List<char> submittedLetters;
    public List<char> currentWord;

    string[] currentString;

    private void Start() 
    {
        GetWord();
    }

    public void NewQuestion()
    {
        char[] currentWordInStringChar = wordHuntManager.CurrentWord().ToCharArray();
        submittedLetters.Clear();
        currentWord.Clear();
        foreach (char character in currentWordInStringChar)
        {
            currentWord.Add(character);
        }

        int children = transform.childCount;

        for (int i = 0; i < children; ++i)
        {
            Debug.Log(i);
            buttons.Add(transform.GetChild(i).gameObject);
        }
            
        foreach (GameObject buttonChoice in buttons)
        {
            buttonChoice.GetComponent<Buttons>().GetAlphabet();
            buttonChoice.GetComponent<Buttons>().ResetButton();
        }

        AudioSource playVoice = GameObject.Find(wordHuntManager.CurrentWord().ToLower()).GetComponent<AudioSource>();
        playVoice.Play();
    }

    public void GetWord()
    {
        char[] currentWordInStringChar = wordHuntManager.CurrentWord().ToCharArray();

        AudioSource playVoice = GameObject.Find(wordHuntManager.CurrentWord().ToLower()).GetComponent<AudioSource>();
        playVoice.Play();

        foreach (char character in currentWordInStringChar)
        {
            currentWord.Add(character);
        }
    }

    public void AddLetter(char letter)
    {
        submittedLetters.Add(letter);

        bool puzzleIsDone = CompareLists(submittedLetters, currentWord);
        Debug.Log(puzzleIsDone);
        if (puzzleIsDone)
        {
            wordHuntManager.QuestionDone();
        }
    }

    public void RemoveLetter(char letter)
    {
        submittedLetters.Remove(letter);

        bool puzzleIsDone = CompareLists(submittedLetters, currentWord);
        Debug.Log(puzzleIsDone);
        if (puzzleIsDone)
        {
            wordHuntManager.QuestionDone();
        }

    }

    public bool CompareLists(List<char> list1, List<char> list2)
    {
        list1.Sort();
        list2.Sort();

        string result1 = "List1 contents: ";
        foreach (var item in list1)
        {
            result1 += item.ToString() + ", ";
        }
        Debug.Log(result1);

        string result2 = "List2 contents: ";
        foreach (var item in list2)
        {
            result2 += item.ToString() + ", ";
        }
        Debug.Log(result2);

        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }

        return true;
    }

}
