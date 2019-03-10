using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer m_lr;
    //[SerializeField] private float x, y;
    [SerializeField] private Transform m_hitPoint;
    [SerializeField] private LayerMask m_hitCheck;
    [SerializeField] private GameObject m_laserSprite; 

    private void Awake()
    {
        //m_lr = GetComponent<LineRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //m_lr.enabled = true;
        //m_lr.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, m_hitCheck);
        Debug.DrawLine(transform.position, hit.point);
        m_hitPoint.position = hit.point;
        m_laserSprite.transform.position = transform.position + (m_hitPoint.position - transform.position) / 2;
        m_laserSprite.transform.localScale = new Vector3(Vector3.Distance(m_hitPoint.position, transform.position)/1.1f, 1f, 1f);
        //m_lr.SetPosition(0, transform.position);
        //m_lr.SetPosition(1, m_hitPoint.transform.position);

        if (hit.transform.CompareTag("Player"))
        {
            GameController.instance.SetPlayerLives(0);
        }
    }
}
