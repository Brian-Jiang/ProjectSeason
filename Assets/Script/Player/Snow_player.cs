using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snow_player : MonoBehaviour
{
    
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
        if( go_up_speed> upper_bound)
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
        if(Time.time>=change_speed)
        {
            if(go_up_speed+0.2f< upper_bound)
            {
                go_up_speed += 0.2f;
            }
            else
            {
                go_up_speed = upper_bound;
            }
            change_speed = Time.time+speed_up;
            //Debug.Log(Time.time);
        }
        
        Move();
        


    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_rb.AddForce(Vector2.left * move_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rb.AddForce(Vector2.right*move_speed);
        }
        m_rb.velocity = Vector2.up * go_up_speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if ( collision.CompareTag("NextScene"))
        {
            SceneManager.LoadScene("End"); //load the thank you for playing scene
        }
        else */if ( collision.CompareTag("Enemy"))
        {
            GameController.instance.SetPlayerLives(0);
        }
    }
   
}
