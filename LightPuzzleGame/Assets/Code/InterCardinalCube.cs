﻿using System.Collections;
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
        List<MirrorCube> FoundMirrors = new List<MirrorCube>();

        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case (0):
                    if (Physics.Raycast(this.transform.position, new Vector3(1, 0, 1), out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            FireParticle(new Vector3(1, 0, 1));

                            if (hit.collider.GetComponent<MirrorCube>() == true)
                            {
                                foundMirror = true;
                                c.FlipOn();
                                FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                            }
                            else
                                c.FlipOn();
                        }
                    }
                    break;

                case (1):
                    if (Physics.Raycast(this.transform.position, new Vector3(1, 0, -1), out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            FireParticle(new Vector3(1, 0, -1));

                            if (hit.collider.GetComponent<MirrorCube>() == true)
                            {
                                foundMirror = true;
                                c.FlipOn();
                                FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                            }
                            else
                                c.FlipOn();
                        }
                    }
                    break;

                case (2):
                    if (Physics.Raycast(this.transform.position, new Vector3(-1, 0, -1), out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            FireParticle(new Vector3(-1, 0, -1));

                            if (hit.collider.GetComponent<MirrorCube>() == true)
                            {
                                foundMirror = true;
                                c.FlipOn();
                                FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                            }
                            else
                                c.FlipOn();
                        }
                    }
                    break;

                case (3):
                    if (Physics.Raycast(this.transform.position, new Vector3(-1, 0, 1), out hit, Mathf.Infinity))
                    {
                        if (hit.collider.TryGetComponent(out Cube c))
                        {
                            //Debug.Log(c.name);
                            FireParticle(new Vector3(-1, 0, 1));

                            if (hit.collider.GetComponent<MirrorCube>() == true)
                            {
                                foundMirror = true;
                                c.FlipOn();
                                FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                            }
                            else
                                c.FlipOn();
                        }
                    }
                    break;

                case (4):
                    if (foundMirror == false)
                        CheckWin();
                    else
                    {
                        foundMirror = false;
                        for (int j = 0; j < FoundMirrors.Count; j++)
                        {
                            FoundMirrors[j].MirrorFunction(this, Vector3.zero);
                        }
                    }
                    break;
            }
        }
    }
}

