using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager: MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        //SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void QuitButton()
    {
        Application.Quit();
    }
}
