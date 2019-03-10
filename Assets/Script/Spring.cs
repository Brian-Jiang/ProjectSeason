using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float m_JumpSpeed = 10f;
    private Rigidbody2D m_rb2d;
    private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerScript>().SetHighJump(false);
            m_rb2d = collision.collider.GetComponent<Rigidbody2D>();
            if(m_rb2d)
            {
                m_rb2d.velocity = new Vector2(0f, m_JumpSpeed);
            }

            m_animator.Play("Mushroom_Jump");
            //m_animator.SetBool("Jump", true);
            //m_animator.SetBool("Jump", false);
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            //collision.collider.GetComponent<PlayerScript>().SetJumpRatio(1/ m_JumpSpeed);
            m_rb2d = collision.collider.GetComponent<Rigidbody2D>();
            if (m_rb2d)
            {
                m_rb2d.velocity = new Vector2(0f, m_JumpSpeed);
            }
        }
    }*/
}
