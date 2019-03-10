using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D m_rb;

    //**********xMovement**********
    private bool enabledMovement = true;
    [SerializeField] private float speed;

    //**********Jumping***********
    [SerializeField] private Transform m_GroundCheck;
    private float m_GroundedRadius = 0.2f;
    [SerializeField] private LayerMask m_Ground;
    [SerializeField]private bool m_Grounded = false;
    [SerializeField] private float m_JumpOffSpeed;
    private bool enabledJump = true;
    [SerializeField]private bool m_HighJump = true;
    
    //**********Animation**********
    private Animator m_animator;
    private SpriteRenderer m_sr;
    private bool FlipX = true;

    //**********Climb**********
    [SerializeField]private bool enabledClimb = false;
    [SerializeField]private bool isClimbing = false;

    private Vector3 m_rb_vel;
    
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sr = GetComponentInChildren<SpriteRenderer>();
        m_animator = GetComponentInChildren<Animator>();
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
                //Debug.Log(colliders[i].tag);
                m_Grounded = true;
                m_HighJump = true;
                m_animator.SetBool("grounded", true);
            }
        }
    }
    
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
        
        m_rb.velocity = new Vector2(xMovement, yMovement);
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

    protected virtual float Jump()
    {
        float yMovement;

        if (Input.GetButtonDown("Jump") && m_Grounded)
        {
            yMovement = m_JumpOffSpeed;
            m_Grounded = false;
            m_animator.SetBool("grounded", false);
        }
        else if(isClimbing)
        {
            yMovement = 0f;
        }
        else
        {
            yMovement = m_rb.velocity.y;

            if (yMovement > 0 && !Input.GetButton("Jump") && m_HighJump)
                yMovement = 0.8f * yMovement;
        }
        
        return yMovement;
    }

    float Climb()
    {
        
        float yMovement = Input.GetAxisRaw("Vertical");

        if (!m_Grounded && yMovement != 0f)
        {
            m_rb.gravityScale = 0;
            isClimbing = true;
        }
        else if(m_Grounded)
        {
            m_rb.gravityScale = 1;
            isClimbing = false;
        }

        return yMovement*2f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vine"))
        {
            enabledClimb = true;
        }
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Vine")&& Input.GetKey(KeyCode.W))
        {
            enabledClimb = true;
            isClimbing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Vine"))
        {
            m_rb.gravityScale = 1;
            enabledClimb = false;
            isClimbing = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            GameController.instance.SetPlayerLives(0);
        }
    }
    
    public void SetSpeedRatio(float ratio)
    {
        speed = speed * ratio;
    }

    public void SetJumpRatio(float ratio)
    {
        m_JumpOffSpeed = m_JumpOffSpeed * ratio;
    }

    public void SetHighJump(bool boolean)
    {
        m_HighJump = boolean;
    }
}
