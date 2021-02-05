using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public static AdsManager adsManager;
    string androidId = "3550638";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (adsManager != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            adsManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += RollForAd;
        Advertisement.Initialize(androidId, false);
    }

    public void RollForAd(Scene s, LoadSceneMode load)
    {
        int roll = Random.Range(1, 100);
        if (roll <= 10)
        {
            //Advertisement.Show();
        }
    }

    public void RollAd()
    {
        int roll = Random.Range(1, 100);
        if (roll <= 10)
        {
            //Advertisement.Show();
        }
    }
}
