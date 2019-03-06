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
    [SerializeField] private Vector2 m_LastCheckPoint = Vector2.zero;
    //[SerializeField]private GameObject[] m_check_points;

    private int m_currentLevel = 1;
    private int m_lives = 1;

    private void Awake()
    {
        //m_check_points = GameObject.FindGameObjectsWithTag("Check Point");

        m_currentLevel = SceneManager.GetActiveScene().buildIndex;

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
        if (m_lives <= 0 && !m_GameOver)
        {
            GameOver();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        if (m_LastCheckPoint != Vector2.zero && m_player)
        {
            m_player.transform.position = m_LastCheckPoint;
        }

        //m_check_points = GameObject.FindGameObjectsWithTag("Check Point");
    }

    /*private void EmptyCheckPoints()
    {
        for (int i = 0; i < m_check_points.Length; i++)
        {
            Destroy(m_check_points[i]);
        }
    }*/

    public void GameOver()
    {
        m_GameOver = true;
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        m_GameOver = false;
        m_lives = 1;
        SceneManager.LoadScene(m_currentLevel);
    }

    public void LoadLevel(int level)
    {
        m_GameOver = false;
        m_lives = 1;
        m_currentLevel = level;
        SceneManager.LoadScene(level);
        m_LastCheckPoint = Vector2.zero;
        //EmptyCheckPoints();
    }

    public void LoadNextLevel()
    {
        m_GameOver = false;
        m_lives = 1;
        m_currentLevel++;
        SceneManager.LoadScene(m_currentLevel);
        m_LastCheckPoint = Vector2.zero;
        //EmptyCheckPoints();
    }

    public void CheckPoint(Vector2 checkpoint)
    {
        m_LastCheckPoint = checkpoint;
    }

    public GameObject GetPlayer()
    {
        return m_player;
    }

    public void SetPlayerLives(int lives)
    {
        m_lives = lives;
    }
}
