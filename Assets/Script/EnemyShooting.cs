using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float x, y;
    [SerializeField] private float speed;
    [SerializeField] private float att_frq;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firep;
    private SpriteRenderer m_render;
    private float nextAttack;
 

    // Start is called before the first frame update
    void Start()
    {
        //m_control = GameObject.FindGameObjectWithTag("GameCon")
        m_render = GetComponentInChildren<SpriteRenderer>();
        if (!firep)
            firep = transform;
        nextAttack = Time.time + att_frq;

    }
    private void Attack()
    {
        
        GameObject bulletobj = Instantiate(bullet, firep.position, transform.rotation);
        Rigidbody2D m_bulletRB =  bulletobj.GetComponent<Rigidbody2D>();
        //Debug.Log(bulletobj.transform.position);
        if (m_bulletRB)
            m_bulletRB.velocity = new Vector2(x, y).normalized * speed;
        nextAttack = Time.time + att_frq;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttack)
        {
            Attack();
        }
    }
}
