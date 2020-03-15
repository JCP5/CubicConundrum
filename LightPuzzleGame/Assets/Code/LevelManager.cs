using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public delegate void Win();
    public event Win winEvent;

    [SerializeField]
    int cubeCount, onCubes;
    [SerializeField]
    GameObject WinScreen;

    private void Awake()
    {
        levelManager = this;
    }

    public void AddCube()
    {
        cubeCount++;
    }

    public void AddOnCubes()
    {
        onCubes++;

        if (onCubes == cubeCount && winEvent != null)
        {
            winEvent();
            WinScreen.SetActive(true);
        }
    }

    public void MinusOnCubes()
    {
        onCubes--;
    }
}
