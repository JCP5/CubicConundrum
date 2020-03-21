using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalCube : Cube
{
    // Start is called before the first frame update
    void Start()
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
                    if (Physics.Raycast(this.transform.position, -Vector3.forward, out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            c.FlipOn();
                        }
                    }
                    break;

                case (1):
                    if (Physics.Raycast(this.transform.position, -Vector3.right, out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            c.FlipOn();
                        }
                    }
                    break;

                case (2):
                    if (Physics.Raycast(this.transform.position, Vector3.forward, out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            c.FlipOn();
                        }
                    }
                    break;

                case (3):
                    if (Physics.Raycast(this.transform.position, Vector3.right, out hit, Mathf.Infinity))
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
