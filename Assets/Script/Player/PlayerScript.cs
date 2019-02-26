using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    UnityEvent in_water;
    UnityEvent on_vine;
    UnityEvent wind;

    private Rigidbody2D m_rb;

    //**********xMovement**********
    private bool enabledMovement = true;
    [SerializeField] private float speed;

    //**********Jumping***********
    [SerializeField] private Transform m_GroundCheck;
    private float m_GroundedRadius = 0.2f;
    [SerializeField] private LayerMask m_Ground;
    private bool m_Grounded = false;
    [SerializeField] private float m_JumpOffSpeed;
    private bool enabledJump = true;

    //**********Animation**********
    private Animator m_animator;
    private SpriteRenderer m_sr;
    private bool FlipX = false;

    //**********Climb**********
    private bool enabledClimb = false;


    private Vector3 m_rb_vel;

    

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sr = GetComponentInChildren<SpriteRenderer>();
        m_animator = GetComponentInChildren<Animator>();
    }

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
            if (colliders[i].gameObject != gameObject && !colliders[i].gameObject.CompareTag("Vine"))
            {
                m_Grounded = true;
                m_animator.SetBool("grounded", true);
            }
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float xMovement = 0f, yMovement = 0f;

        if (enabledMovement)
        {
            xMovement += Move();
        }

        if(enabledJump)
        {
            yMovement += Jump();
        }

        if (enabledClimb)
        {
            yMovement += Climb();
        }

        m_animator.SetFloat("speed", Mathf.Abs(m_rb.velocity.x));

        m_rb.velocity = new Vector2(xMovement, yMovement);
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

    protected virtual float Jump()
    {
        float yMovement;

        if (Input.GetButtonDown("Jump") && m_Grounded)
        {
            yMovement = m_JumpOffSpeed;
            m_Grounded = false;
            m_animator.SetBool("grounded", false);
        }
        else
        {
            yMovement = m_rb.velocity.y;

            if (yMovement > 0 && !Input.GetButton("Jump"))
                yMovement = 0.5f * yMovement;
        }
        return yMovement;
    }

    float Climb()
    {
        float yMovement = Input.GetAxisRaw("Vertical");
        m_Grounded = false;

        return yMovement*2f;
    }


    void OnTriggerEnter2D(Collider2D collision)//maybe stay2d
    {

        if (collision.CompareTag("Vine"))
        {
            m_rb.gravityScale = 0;
            m_rb.velocity = Vector2.zero;
            enabledClimb = true;
            enabledJump = false;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Vine"))
        {
            m_rb.gravityScale = 1;
            enabledClimb = false;
            enabledJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
             this.transform.parent = collision.collider.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }
    }
}
