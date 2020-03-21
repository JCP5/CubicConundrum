using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public delegate void Win();
    public event Win winEvent;
    public bool tutorial = false;
    public Text numOfTapsText, solvedNumberText, solvableText;
    int startingOnCubes;

    [SerializeField]
    bool[] cubeStartStates;

    [SerializeField]
    int cubeCount, offCubes, numOfTaps = 0;

    [SerializeField]
    GameObject winScreen, tutorialScreen, levelInfo, solution;

    [SerializeField]
    List<Cube> cubesInLevel = new List<Cube>();

    private void Awake()
    {
        levelManager = this;
    }

    private void Start()
    {
        if (cubesInLevel.Count < 1)
        {
            foreach (Cube c in FindObjectsOfType<Cube>())
            {
                cubesInLevel.Add(c);
                c.ChangeEmission();

                if (c.on)
                    startingOnCubes++;

                //Subtracting while iterating through a collection in the middle causes an off by 1 error
                //IE. Subtract one from your iterator while counting up on any number between the start and the end
                //If your total is 9 and you subtract 1 on 5 then the total will be 7
                //** Use your fingers if you don't believe me
                UpdateCubes(false);
            }
            offCubes -= startingOnCubes;
        }

        cubeCount = cubesInLevel.Count;
        IntializeCubeStartStates();
        CheckTutorial();
    }

    void IntializeCubeStartStates()
    {
        cubeStartStates = new bool[cubesInLevel.Count];

        for (int i = 0; i < cubesInLevel.Count; i++)
        {
            cubeStartStates[i] = cubesInLevel[i].on;
        }
    }

    public void CheckTutorial()
    {
        if (tutorial == true)
        {
            tutorialScreen.GetComponent<Tutorial>().StartTutorial();
            tutorialScreen.SetActive(true);
        }
        else
        {
            EnableCubes();
            EnableLevelInfo();
        }
    }

    void EnableCubes()
    {
        foreach (Cube c in cubesInLevel)
            c.enabled = true;
    }

    void EnableLevelInfo()
    {
        solvableText.text = CountSolution();
        levelInfo.SetActive(true);
    }

    public void UpdateCubes(bool countIf)
    {
        if (countIf)
            MinusoffCubes();
        else
            AddoffCubes();
    }

    public void AddCube()
    {
        cubeCount++;
    }

    void AddoffCubes()
    {
        offCubes++;
    }

    void MinusoffCubes()
    {
        offCubes--;
    }

    //CheckWin() is called by each cube type after shooting all of their raycasts
    public void CheckWin()
    {
        if (offCubes == 0 && winEvent != null)
        {
            winEvent();
            solvedNumberText.text = "You solved using " + numOfTaps + " taps";
            winScreen.SetActive(true);
            levelInfo.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        for (int i = 0; i < cubesInLevel.Count; i++)
        {
            cubesInLevel[i].on = cubeStartStates[i];
            cubesInLevel[i].ChangeEmission();
        }

        offCubes = cubeCount - startingOnCubes;
        numOfTaps = 0;
        numOfTapsText.text = "Taps " + numOfTaps;
    }

    public void AddNumOfTaps()
    {
        numOfTaps++;
        numOfTapsText.text = "Taps " + numOfTaps;
    }

    string CountSolution()
    {
        int solutionLength = 0;

        foreach (Transform t in solution.GetComponentsInChildren<Transform>())
        {
            if (t.parent != null && t.parent != this.gameObject.transform)
            {
                solutionLength++;
            }
        }

        return "This puzzle can be solved in " + solutionLength + " moves";
    }
}
