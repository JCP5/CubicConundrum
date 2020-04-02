using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCube : Cube
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    public override void FindNext()
    {
        CheckWin();
    }

    public void MirrorFunction(Cube origin, Vector3 originVector)
    {
        Vector3 originFlip = new Vector3(originVector.x * -1, originVector.y * -1, originVector.z * -1);
        List<Vector3> FoundMirrorVectors = new List<Vector3>();
        List<MirrorCube> FoundMirrors = new List<MirrorCube>();

        RaycastHit hit;
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case (0):
                    if (origin is InterCardinalCube)
                    {
                        Vector3 castVector = new Vector3(1, 0, 1);

                        if (castVector != originFlip)
                        {
                            if (Physics.Raycast(this.transform.position, castVector, out hit, Mathf.Infinity))
                            {
                                if (hit.collider.TryGetComponent(out Cube c))
                                {
                                    //Debug.Log(c.name);
                                    FireParticle(castVector);

                                    if (hit.collider.GetComponent<MirrorCube>() == true)
                                    {
                                        foundMirror = true;
                                        c.FlipOn();
                                        FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                                        FoundMirrorVectors.Add(castVector);
                                    }
                                    else
                                        c.FlipOn();
                                }
                            }
                        }
                    }
                    else if (origin is CardinalCube)
                    {
                        Vector3 castVector = -Vector3.forward;

                        if (castVector != originFlip)
                        {
                            if (Physics.Raycast(this.transform.position, castVector, out hit, Mathf.Infinity))
                            {
                                if (hit.collider.TryGetComponent(out Cube c))
                                {
                                    //Debug.Log(c.name);
                                    FireParticle(castVector);

                                    if (hit.collider.GetComponent<MirrorCube>() == true)
                                    {
                                        foundMirror = true;
                                        c.FlipOn();
                                        FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                                        FoundMirrorVectors.Add(castVector);
                                    }
                                    else
                                        c.FlipOn();
                                }
                            }
                        }
                    }
                    break;

                case (1):
                    if (origin is InterCardinalCube)
                    {
                        Vector3 castVector = new Vector3(1, 0, -1);
                        if (castVector != originFlip)
                        {
                            if (Physics.Raycast(this.transform.position, castVector, out hit, Mathf.Infinity))
                            {
                                if (hit.collider.TryGetComponent(out Cube c))
                                {
                                    //Debug.Log(c.name);
                                    FireParticle(castVector);

                                    if (hit.collider.GetComponent<MirrorCube>() == true)
                                    {
                                        foundMirror = true;
                                        c.FlipOn();
                                        FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                                        FoundMirrorVectors.Add(castVector);
                                    }
                                    else
                                        c.FlipOn();
                                }
                            }
                        }
                    }
                    else if (origin is CardinalCube)
                    {
                        Vector3 castVector = -Vector3.right;
                        if (castVector != originFlip)
                        {
                            if (Physics.Raycast(this.transform.position, castVector, out hit, Mathf.Infinity))
                            {
                                if (hit.collider.TryGetComponent(out Cube c))
                                {
                                    //Debug.Log(c.name);
                                    FireParticle(castVector);

                                    if (hit.collider.GetComponent<MirrorCube>() == true)
                                    {
                                        foundMirror = true;
                                        c.FlipOn();
                                        FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                                        FoundMirrorVectors.Add(castVector);
                                    }
                                    else
                                        c.FlipOn();
                                }
                            }
                        }
                    }
                    break;

                case (2):
                    if (origin is InterCardinalCube)
                    {
                        Vector3 castVector = new Vector3(-1, 0, -1);
                        if (castVector != originFlip)
                        {
                            if (Physics.Raycast(this.transform.position, castVector, out hit, Mathf.Infinity))
                            {
                                if (hit.collider.TryGetComponent(out Cube c))
                                {
                                    //Debug.Log(c.name);
                                    FireParticle(castVector);

                                    if (hit.collider.GetComponent<MirrorCube>() == true)
                                    {
                                        foundMirror = true;
                                        c.FlipOn();
                                        FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                                        FoundMirrorVectors.Add(castVector);
                                    }
                                    else
                                        c.FlipOn();
                                }
                            }
                        }
                    }
                    else if (origin is CardinalCube)
                    {
                        Vector3 castVector = Vector3.forward;
                        if (castVector != originFlip)
                        {
                            if (Physics.Raycast(this.transform.position, castVector, out hit, Mathf.Infinity))
                            {
                                if (hit.collider.TryGetComponent(out Cube c))
                                {
                                    //Debug.Log(c.name);
                                    FireParticle(castVector);

                                    if (hit.collider.GetComponent<MirrorCube>() == true)
                                    {
                                        foundMirror = true;
                                        c.FlipOn();
                                        FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                                        FoundMirrorVectors.Add(castVector);
                                    }
                                    else
                                        c.FlipOn();
                                }
                            }
                        }
                    }
                    break;

                case (3):
                    if (origin is InterCardinalCube)
                    {
                        Vector3 castVector = new Vector3(-1, 0, 1);
                        if (castVector != originFlip)
                        {
                            if (Physics.Raycast(this.transform.position, castVector, out hit, Mathf.Infinity))
                            {
                                if (hit.collider.TryGetComponent(out Cube c))
                                {
                                    //Debug.Log(c.name);
                                    FireParticle(castVector);

                                    if (hit.collider.GetComponent<MirrorCube>() == true)
                                    {
                                        foundMirror = true;
                                        c.FlipOn();
                                        FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                                        FoundMirrorVectors.Add(castVector);
                                    }
                                    else
                                        c.FlipOn();
                                }
                            }
                        }
                    }
                    else if (origin is CardinalCube)
                    {
                        Vector3 castVector = Vector3.right;
                        if (castVector != originFlip)
                        {
                            if (Physics.Raycast(this.transform.position, castVector, out hit, Mathf.Infinity))
                            {
                                if (hit.collider.TryGetComponent(out Cube c))
                                {
                                    //Debug.Log(c.name);
                                    FireParticle(castVector);

                                    if (hit.collider.GetComponent<MirrorCube>() == true)
                                    {
                                        foundMirror = true;
                                        c.FlipOn();
                                        FoundMirrors.Add(hit.collider.GetComponent<MirrorCube>());
                                        FoundMirrorVectors.Add(castVector);
                                    }
                                    else
                                        c.FlipOn();
                                }
                            }
                        }
                    }
                    break;

                case (4):
                    if (foundMirror == false)
                    {
                        CheckWin();
                    }
                    else
                    {
                        foundMirror = false;
                        for (int j = 0; j < FoundMirrorVectors.Count; j++)
                        {
                            FoundMirrors[j].MirrorFunction(origin, FoundMirrorVectors[j]);
                        }
                    }

                    break;
            }
        }
    }
}
