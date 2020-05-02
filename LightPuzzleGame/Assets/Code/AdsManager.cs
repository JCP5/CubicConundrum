using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    string androidId = "3550638";

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(androidId, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
