using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Movement
{
    public float x, y, time;
}

public class Platform : MonoBehaviour
{
    [SerializeField] private Movement[] m_movements;
    private Rigidbody2D m_rb2d;
    [SerializeField] private bool loop;
    private int index = 0;

    private void Awake()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    void NextMove()
    {
        if(index < m_movements.Length)
        {
            StartCoroutine(Move(new Vector2(m_movements[index].x, m_movements[index].y), m_movements[index].time));
            
        }
        else if(loop)
        {
            index = 0;
            StartCoroutine(Move(new Vector2(m_movements[index].x, m_movements[index].y), m_movements[index].time));
        }
        index++;
    }

    // Start is called before the first frame update
    void Start()
    {
        NextMove();
    }

    IEnumerator Move(Vector2 movement, float time)
    {
        m_rb2d.velocity = movement / time;
        //Debug.Log(index + " " + movement + " " + time);
        yield return new WaitForSeconds(time);
        m_rb2d.velocity = Vector2.zero;
        NextMove();
    }
}
