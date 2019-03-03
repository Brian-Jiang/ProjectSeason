using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager: MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        GameController.instance.LoadLevel(2);
    }

    public void ResumeButton()
    {
        GameController.instance.ReloadLevel();
    }

    // Update is called once per frame
    public void QuitButton()
    {
        Application.Quit();
    }

    public void ToStartMenuButton()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
