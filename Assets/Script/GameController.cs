using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject m_player;
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
<<<<<<< HEAD
        // following are the getting player
        m_player = GameObject.FindGameObjectWithTag("Player");
    }
    public GameObject GetPlayer()
    {
        return m_player;
    }
    // Start is called before the first frame update
    void Start()
    {
        
=======

        m_player = GameObject.FindGameObjectWithTag("Player");

>>>>>>> e74cc51e03545ea67ed9cfc006b1466910869dcb
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
=======
        if (m_GameOver && Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel();
        }
    }

    public void GameOver()
    {
        if(!textManagerScript)
            textManagerScript = GameObject.FindGameObjectWithTag("Text Manager").GetComponent<TextManager>();
        textManagerScript.SetGameStatusText("Game Over\n Press 'R' to Restart");
        m_GameOver = true;
    }

    public void LoadLevel()
    {
        m_GameOver = false;
        SceneManager.LoadScene("Prototype");
    }

    public GameObject GetPlayer()
    {
        return m_player;
>>>>>>> e74cc51e03545ea67ed9cfc006b1466910869dcb
    }
}
