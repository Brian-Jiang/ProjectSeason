using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager: MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameController.instance.GetCurrentScene() == 1)
        {
            ResumeButton();
        }
    }

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
        GameController.instance.LoadLevel(0);
    }

    public static void ToStartMenu()
    {
        //ToStartMenuButton();
    }
}
