using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigation : MonoBehaviour
{
    [SerializeField]
    GameObject about, menubuttons;

    private void Start()
    {
        if (this.gameObject.tag == "LevelSelectButton")
        {
            GetComponentInChildren<Text>().text = this.name;
        }
    }

    public void About()
    {
        menubuttons.SetActive(false);
        about.SetActive(true);
    }

    public void BackFromAbout()
    {
        about.SetActive(false);
        menubuttons.SetActive(true);
    }

    public void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            this.GetComponent<AudioSource>().Play();
        }

        int index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel()
    {
        int i = int.Parse(this.gameObject.name);
        SceneManager.LoadScene(i);
    }
}
