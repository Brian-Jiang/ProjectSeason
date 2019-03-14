using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Sprite m_CheckedPoint;
    private SpriteRenderer m_sprd;
    public bool m_isTriggered = false;
    [SerializeField] private AudioClip m_audioClip;

    private void Awake()
    {
        m_sprd = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameController.instance.CheckPoint(this.transform.position);
            GameController.instance.PlayAudioClip(m_audioClip);
            m_sprd.sprite = m_CheckedPoint;
            Destroy(this);
        }
    }
}
