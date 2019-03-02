using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidenRoom : MonoBehaviour
{
    private SpriteRenderer m_sprd;
    private Color m_color;
    [SerializeField]private bool m_FadingOut = false;
    [SerializeField]private bool m_FadingIn = false;
    [SerializeField]private float m_curTrans;
    [SerializeField]private float m_tarTrans;

    static float t = 0f;

    private void Awake()
    {
        m_sprd = GetComponent<SpriteRenderer>();
        m_color = m_sprd.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_FadingOut || m_FadingIn)
        {
            t += 2f * Time.deltaTime;
            m_color.a = Mathf.Lerp(m_curTrans, m_tarTrans, t);
            m_sprd.color = m_color;
        }
        else if(m_color.a == m_tarTrans)
        {
            m_FadingIn = false;
            m_FadingOut = false;
        }
    }

    void FadeOut()
    {
        t = 0f;
        m_curTrans = m_sprd.color.a;
        m_tarTrans = 0f;
        m_FadingOut = true;
        m_FadingIn = false;
    }

    void FadeIn()
    {
        t = 0f;
        m_curTrans = m_sprd.color.a;
        m_tarTrans = 1f;
        m_FadingOut = false;
        m_FadingIn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FadeOut();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FadeIn();
        }
    }
}
