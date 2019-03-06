using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Sprite m_CheckedPoint;
    private SpriteRenderer m_sprd;
    public bool m_isTriggered = false;

    private void Awake()
    {
        m_sprd = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameController.instance.CheckPoint(this.gameObject);
            m_sprd.sprite = m_CheckedPoint;
            m_isTriggered = true;
        }
        Debug.Log(collision.tag + " " + this.tag);
        if (collision.CompareTag(this.tag))
        {
            
            if (m_isTriggered)
                Destroy(collision.gameObject);
        }
    }
}
