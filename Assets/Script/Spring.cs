using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float m_JumpSpeed = 10f;
    private Rigidbody2D m_rb2d;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_rb2d = collision.GetComponent<Rigidbody2D>();
            if(m_rb2d)
            {
                m_rb2d.velocity = new Vector2(0f, m_JumpSpeed);
            }
        }
    }
}
