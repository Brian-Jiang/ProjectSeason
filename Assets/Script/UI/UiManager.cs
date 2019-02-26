using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager: MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        SceneManager.LoadScene("Prototype");
    }

    // Update is called once per frame
    public void QuitButton()
    {
        Application.Quit();
    }
}
