using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    string[] tutorialPages = new string[0];

    [SerializeField]
    int index = 0;

    [SerializeField]
    Text tutorialText;

    public void StartTutorial()
    {
        tutorialText.text = tutorialPages[index];
    }

    public void CycleTutorial()
    {
        index++;
        if (index < tutorialPages.Length)
        {
            tutorialText.text = tutorialPages[index];
        }
        else
        {
            LevelManager.levelManager.tutorial = false;
            LevelManager.levelManager.CheckTutorial();
            this.gameObject.SetActive(false);
        }
    }
}
