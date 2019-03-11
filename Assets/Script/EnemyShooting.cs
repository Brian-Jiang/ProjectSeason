using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float x, y;
    [SerializeField] private float speed;
    [SerializeField] private float att_frq;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firep;
    [SerializeField] private bool trackingbul;
    private GameObject cur_player;
    private SpriteRenderer m_render;
    private float nextAttack;
 

    // Start is called before the first frame update
    void Start()
    {
        cur_player = GameController.instance.GetPlayer();
        //m_control = GameObject.FindGameObjectWithTag("GameCo")
        m_render = GetComponentInChildren<SpriteRenderer>();
        if (!firep)
            firep = transform;
        nextAttack = Time.time + att_frq;

    }
    private void Attack()
    {
        if (trackingbul == false)
        {
            GameObject bulletobj = Instantiate(bullet, firep.position, transform.rotation);
            Rigidbody2D m_bulletRB = bulletobj.GetComponent<Rigidbody2D>();
            if (m_bulletRB)
                m_bulletRB.velocity = new Vector2(x, y).normalized * speed;
        }
        else
        {
            GameObject bulletobj = Instantiate(bullet, firep.position, transform.rotation);
            Bullet_Tra bullet_t = bulletobj.GetComponent<Bullet_Tra>();
            bullet_t.SetTarget(cur_player);
        }

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
