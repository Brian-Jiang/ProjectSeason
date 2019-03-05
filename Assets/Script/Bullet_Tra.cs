using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Tra : MonoBehaviour
{
    
    public SpriteRenderer render;
    private GameObject target;
    private Rigidbody2D m_rdg;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float lifeTime = 5f;
    private Vector2 currentDirection;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime += Time.time;
        render = GetComponent<SpriteRenderer>();
        m_rdg = GetComponent<Rigidbody2D>();
        if (target != null)
        {
            Debug.Log("Not null");
            currentDirection = (target.transform.position - transform.position).normalized;

            m_rdg.AddForce(currentDirection * speed);
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (Time.time > lifeTime)
        {
            Destroy(gameObject);
        }
        

        
        if(target)
            direction = (target.transform.position - transform.position).normalized;
        
        float angle = Vector2.SignedAngle(currentDirection, direction);

        float sin = Mathf.Sin(rotateSpeed * Mathf.Sign(angle) * Mathf.Deg2Rad * Time.deltaTime);
        float cos = Mathf.Cos(rotateSpeed * Mathf.Sign(angle) * Mathf.Deg2Rad * Time.deltaTime);

        float tx = currentDirection.x;
        float ty = currentDirection.y;

        currentDirection = new Vector2((cos * tx) - (sin * ty), (sin * tx) + (cos * ty));


        transform.Rotate(0f, 0f, rotateSpeed * Mathf.Sign(angle) * Time.deltaTime);

        m_rdg.velocity = currentDirection * speed;
        //m_rdg.AddForce(direction * speed);

    }

    public void SetTarget(GameObject Target)
    {
        target = Target;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("dis player");
            GameController.instance.SetPlayerLives(0);
        }
    }

}
