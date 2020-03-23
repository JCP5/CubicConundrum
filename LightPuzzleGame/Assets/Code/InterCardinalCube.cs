using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterCardinalCube : Cube
{
    private void Start()
    {
        base.Start();
    }

    public override void FindNext()
    {
        RaycastHit hit;
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case (0):
                    if (Physics.Raycast(this.transform.position, new Vector2(1, 1), out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            c.FlipOn();
                        }
                    }
                    break;

                case (1):
                    if (Physics.Raycast(this.transform.position, new Vector2(1, -1), out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            c.FlipOn();
                        }
                    }
                    break;

                case (2):
                    if (Physics.Raycast(this.transform.position, new Vector2(-1, -1), out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            c.FlipOn();
                        }
                    }
                    break;

                case (3):
                    if (Physics.Raycast(this.transform.position, new Vector2(-1, 1), out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            c.FlipOn();
                        }
                    }
                    break;

                case (4):
                    CheckWin();
                    break;
            }
        }
    }
}

