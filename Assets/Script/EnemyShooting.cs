using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] public float att_dis;
    [SerializeField] public float att_frq;
    [SerializeField] public GameObject bullet;
    private GameObject cur_player;
    private GameController m_control;
    // Start is called before the first frame update
    void Start()
    {
        //m_control = GameObject.FindGameObjectWithTag("GameCon")
        m_control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        cur_player = m_control.GetPlayer();
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
