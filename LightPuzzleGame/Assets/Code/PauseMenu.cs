using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : SceneNavigation
{
    public GameObject pauseMenu;

    public void PauseOn()
    {
        pauseMenu.SetActive(true);
        FindObjectOfType<Pointer>().enabled = false;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        FindObjectOfType<Pointer>().enabled = true;
    }
}
