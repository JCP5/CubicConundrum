using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Material mat;
    public Color onColor;
    public bool on = false;

    // Start is called before the first frame update
    public void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");

        LevelManager.levelManager.winEvent += OnWin;
        LevelManager.levelManager.AddCube();
    }

    public virtual void FindNext()
    {

    }

    public void ChangeEmission()
    {
        on = !on;
        if (on)
        {
            LevelManager.levelManager.AddOnCubes();
            mat.SetColor("_EmissionColor", onColor);
        }
        else
        {
            LevelManager.levelManager.MinusOnCubes();
            mat.SetColor("_EmissionColor", Color.black);
        }
    }

    public void OnWin()
    {
        this.enabled = false;
        Debug.Log("You win");
    }
}
