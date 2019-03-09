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
    [SerializeField] private bool loop;
    private int index = 0;
    private bool m_isMoving = false;
    private Vector2 m_movement;

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

    private void Update()
    {
        if(m_isMoving)
            this.transform.Translate(m_movement * Time.deltaTime);
    }

    IEnumerator Move(Vector2 movement, float time)
    {
        m_movement = movement / time;
        m_isMoving = true;
        yield return new WaitForSeconds(time);
        m_isMoving = false;
        NextMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.parent = this.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.parent = null;
    }
}
