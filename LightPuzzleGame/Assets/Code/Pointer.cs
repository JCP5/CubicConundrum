using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public bool testingMode;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.levelManager.winEvent += OnWin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || testingMode == true)
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        if (testingMode == false)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.TryGetComponent(out Cube c))
                    {
                        LevelManager.levelManager.AddNumOfTaps();
                        //Debug.Log(c.name);
                        c.FlipOn();
                        c.FindNext();
                    }
                }
            }
        }
        else if (testingMode == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.TryGetComponent(out Cube c))
                    {
                        LevelManager.levelManager.AddNumOfTaps();
                        //Debug.Log(c.name);
                        c.FlipOn();
                        c.FindNext();
                    }
                }
            }
        }
    }

    public void OnWin()
    {
        this.enabled = false;
    }
}
