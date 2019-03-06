using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenLeaves : MonoBehaviour
{
    private PlayerScript m_player;
    [SerializeField] private float ratio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_player = collision.gameObject.GetComponent<PlayerScript>();
            if (m_player)
                m_player.SetSpeedRatio(ratio);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_player = collision.gameObject.GetComponent<PlayerScript>();
            if (m_player)
                m_player.SetSpeedRatio(1 / ratio);
        }
    }
}
