using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D m_rb;
    [SerializeField] public float go_up_speed;
    [SerializeField] public Transform player_p;
    [SerializeField] public float move_speed;
    [SerializeField] public float speed_up;
    [SerializeField] public float upper_bound;
    private float change_speed;



    // Start is called before the first frame update
    void Start()
    {


        //Debug.Log(go_up_speed);

        go_up_speed += (int)(Time.time / speed_up) * 0.2f;
        if (go_up_speed > upper_bound)
        {
            go_up_speed = upper_bound;
        }


        m_rb = GetComponent<Rigidbody2D>();
        m_rb.gravityScale = 0;
        player_p = GetComponent<Transform>();
        m_rb.AddForce(Vector2.up * go_up_speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= change_speed)
        {
            if (go_up_speed + 0.2f < upper_bound)
            {
                go_up_speed += 0.2f;
            }
            else
            {
                go_up_speed = upper_bound;
            }
            change_speed = Time.time + speed_up;
            //Debug.Log(Time.time);
        }

        Move();



    }
    void Move()
    {
        
        m_rb.velocity = Vector2.up * go_up_speed;
    }
}
