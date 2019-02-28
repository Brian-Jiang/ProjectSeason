using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private static GameObject m_player;


    private bool m_GameOver = false;
    private GameObject textManagerScript;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(this);
        
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    public GameObject GetPlayer()
    {
        return m_player;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_GameOver && Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel();
        }
    }

    public void GameOver()
    {
        if(!textManagerScript)
            textManagerScript = GameObject.FindGameObjectWithTag("Text Manager");
        if(textManagerScript)
            textManagerScript.GetComponent<TextManager>().SetGameStatusText("Game Over\n Press 'R' to Restart");
        m_GameOver = true;
    }

    public void LoadLevel()
    {
        m_GameOver = false;
        SceneManager.LoadScene("Prototype");
    }
}
