using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public delegate void Win();
    public event Win winEvent;
    public bool tutorial = false;
    public Text numOfTapsText, solvedNumberText, solvableText, levelText;
    int startingOnCubes;

    public GameObject ambience;
    public GameObject prefabCamera;
    public GameObject pauseMenu;

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
        if (FindObjectOfType<Ambience>() == false)
        {
            Instantiate(ambience, Vector3.zero, Quaternion.identity);
        }

        if (FindObjectOfType<Pointer>() == true)
        {
            Transform oldCamera = FindObjectOfType<Pointer>().gameObject.transform;
            Instantiate(prefabCamera, oldCamera.position, oldCamera.rotation);
            Destroy(oldCamera.gameObject);
        }

        if (FindObjectOfType<PauseMenu>() == false)
        {
            Instantiate(pauseMenu, Vector3.zero, Quaternion.identity);
        }

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
            //Count all cubes then subtract the number of OnCubes for starting number of OffCubes
            offCubes -= startingOnCubes;
        }

        levelText.text = SceneManager.GetActiveScene().buildIndex.ToString();

        cubeCount = cubesInLevel.Count;
        IntializeCubeStartStates();
        InitializeSolutionPositions();
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

    void InitializeSolutionPositions()
    {
        foreach(Transform t in solution.GetComponentInChildren<Transform>())
        {
            foreach(Cube c in cubesInLevel)
            {
                if (t.name == c.transform.parent.name)
                    t.position = c.transform.position;
            }
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
        {
            c.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void EnableLevelInfo()
    {
        solvableText.text = CountSolution();
        levelInfo.SetActive(true);
    }

    public void PauseOn()
    {
        pauseMenu.SetActive(true);
        FindObjectOfType<Pointer>().enabled = false;
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
        bool falseFound = false;

        foreach (Cube c in FindObjectsOfType<Cube>())
        {
            if (c.on == false)
            {
                falseFound = true;
            }
        }

        if (falseFound == false)
        {
            winEvent();
            solvedNumberText.text = "You solved using " + numOfTaps + " taps";
            winScreen.SetActive(true);
            levelInfo.SetActive(false);
        }

        /*Debug.Log("OffCubes is: " + offCubes);
        if (offCubes == 0 && winEvent != null)
        {
            winEvent();
            solvedNumberText.text = "You solved using " + numOfTaps + " taps";
            winScreen.SetActive(true);
            levelInfo.SetActive(false);
        }*/
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

    public void ShowSolution()
    {
        foreach (Animator a in solution.GetComponentsInChildren<Animator>())
            a.Play("FadeOut", -1, 0f);

        //AdsManager.adsManager.RollAd();
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
