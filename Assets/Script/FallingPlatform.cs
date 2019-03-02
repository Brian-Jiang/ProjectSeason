using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float m_FallDelay;
    [SerializeField] private float m_FallSpeed;
    private bool m_isFalling = false;
    private Rigidbody2D m_rb2d;
    private float m_FallTime = 0f;

    private void Awake()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !m_isFalling)
        {
            m_FallTime = Time.time + m_FallDelay;
            m_isFalling = true;
        }
    }

    private void Update()
    {
        if(Time.time > m_FallTime && m_isFalling)
            this.transform.Translate(new Vector2(0, m_FallSpeed * Time.deltaTime));
    }
}
