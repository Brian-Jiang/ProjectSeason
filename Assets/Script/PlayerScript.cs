using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D m_rb;
    //*******environment*************
    private WaterEnv inwater;
    //**********xMovement**********
    private bool enabledMovement = true;
    [SerializeField] private float speed;

    //**********Jumping***********
    [SerializeField]private Transform m_GroundCheck;
    private float m_GroundedRadius = 0.2f;
    [SerializeField] private LayerMask m_Ground;
    [SerializeField]private bool m_Grounded = false;
    [SerializeField] private float m_JumpOffSpeed;
    //private bool m_Jumping = false;

    //**********Animation**********
    private Animator m_animator;
    private SpriteRenderer m_sr;
    private bool FlipX = false;
    

    private Vector3 m_rb_vel;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sr = GetComponentInChildren<SpriteRenderer>();
        m_animator = GetComponentInChildren<Animator>();
        inwater = GetComponent<WaterEnv>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        m_Grounded = false;
        m_animator.SetBool("grounded", false);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, m_GroundedRadius, m_Ground);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                //if(m_rb.velocity.y <= 0)
                m_Grounded = true;
                m_animator.SetBool("grounded", true);
                //m_Jumping = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enabledMovement)
        {
            float xMovement = Move();
            float yMovement = Jump();
            m_rb.velocity = new Vector2(xMovement, yMovement);
        }


        m_animator.SetFloat("speed", Mathf.Abs(m_rb.velocity.x));
    }

    private float Move()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");

        if ((xMovement > 0 && !FlipX) || (xMovement < 0 && FlipX))
        {
            FlipX = !FlipX;
            m_sr.flipX = FlipX;
        }

        return xMovement * speed;
    }

    private float Jump()
    {
        float yMovement;

        if(Input.GetButtonDown("Jump") && m_Grounded)
        {
            yMovement = m_JumpOffSpeed;
            //Debug.Log("Jumped");
            m_Grounded = false;
            m_animator.SetBool("grounded", false);
        }
        //else
        //    yMovement = m_rb.velocity.y;
        else 
        {
            yMovement = m_rb.velocity.y;

            if (yMovement > 0 && !Input.GetButton("Jump"))
                yMovement = 0.5f * yMovement;
        }

        return yMovement;
    }


    void OnTriggerEnter2D(Collider2D collision)//maybe stay2d
    {
        if (collision.CompareTag("Water"))
        {
            m_Grounded = false;
            inwater.enabled = true;

        }
        else if (collision.CompareTag("Vine"))
        {
            m_Grounded = false;
            m_rb.gravityScale = 0;
            m_rb.velocity = Vector2.zero;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            inwater.enabled = false;
        }
        else if (collision.CompareTag("Vine"))
        {
            m_rb.gravityScale = 1;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Vine"))
        {
            m_Grounded = false;

            if (Input.GetKey(KeyCode.W))
            {
                m_rb.AddForce(Vector2.up * 8f);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                m_rb.AddForce(Vector2.down * 8f);
            }
        }
    }
}
