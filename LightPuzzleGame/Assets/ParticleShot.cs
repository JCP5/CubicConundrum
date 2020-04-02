using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShot : MonoBehaviour
{
    public Vector3 direction;
    public float moveSpeed;
    Vector3 origin;
    public Color particleColor;

    // Start is called before the first frame update
    void Start()
    {
        Material mat = this.GetComponent<Material>();
        ChangeParticleColor(particleColor);

        origin = this.transform.position;
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.transform.position != origin)
            direction = Vector3.zero;
    }

    void ChangeParticleColor(Color c)
    {
        Renderer rend = this.GetComponent<ParticleSystem>().GetComponent<Renderer>();
        rend.material.SetColor("_BaseColor", particleColor);
        rend.material.SetColor("_EmissionColor", particleColor);
    }
}
