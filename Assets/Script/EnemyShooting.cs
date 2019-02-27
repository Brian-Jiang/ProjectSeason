using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] public float att_dis;
    [SerializeField] public float att_frq;
    [SerializeField] public GameObject tra_bullet;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Vector3 firep;
    [SerializeField] public bool trackingbul = false;
    private GameObject cur_player;
    private GameController m_control;
    private SpriteRenderer m_render;
    private float nextAttack;
    private Vector2 firePosition;
 

    // Start is called before the first frame update
    void Awake()
    {
        //m_control = GameObject.FindGameObjectWithTag("GameCon")
        m_control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        cur_player = m_control.GetPlayer();
        m_render = this.GetComponent<SpriteRenderer>();
        nextAttack = Time.time + att_frq;

    }
    private void Attack()
    {
        if ((cur_player.transform.position.x - transform.position.x) < 0)
        {
            firePosition = transform.position + firep;
        }
        else
        {
            firePosition = transform.position - firep;
        }
       
        
        if(trackingbul == false)
        {
            GameObject bulletobj = Instantiate(bullet, firePosition, transform.rotation);
            Bullet bullet_n = bulletobj.GetComponent<Bullet>();
            bullet_n.SetTarget(cur_player);
        }
        else
        {
            GameObject bulletobj = Instantiate(tra_bullet, firePosition, transform.rotation);
            Bullet_Tra bullet_t = bulletobj.GetComponent<Bullet_Tra>();
            bullet_t.SetTarget(cur_player);
        }
        
        nextAttack = Time.time + att_frq;
    }

    // Update is called once per frame
    void Update()
    {
        if (cur_player == null)
            return;

        if ((cur_player.transform.position.x - transform.position.x) < 0)
        {
            m_render.flipX = true;
            
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            m_render.flipX = false;
            //transform.localScale = new Vector3(1, 1, 1);
        }


        if (Time.time >= nextAttack)
        {
            if ((cur_player.transform.position - transform.position).magnitude <= att_dis)
                Attack();
        }
    }
}
