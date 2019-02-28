using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    private static GameObject m_player;

    private bool m_GameOver = false;
    [SerializeField]private Vector2 m_LastCheckPoint = Vector2.zero;

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

    void Update()
    {
        if (m_GameOver && Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        if (m_LastCheckPoint != Vector2.zero)
        {
            m_player.transform.position = m_LastCheckPoint;
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

    public void CheckPoint(Vector2 checkpoint)
    {
        m_LastCheckPoint = checkpoint;
    }

    public GameObject GetPlayer()
    {
        return m_player;
    }
}
