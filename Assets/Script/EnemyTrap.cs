using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrap : MonoBehaviour
{
    [SerializeField] private GameObject m_enemy;
    [SerializeField] private float x, y;
    [SerializeField] private float m_SpawnVelocity;
    [SerializeField] private Transform m_SpawnPosition;
    private Rigidbody2D m_enemyRb2d;

    // Start is called before the first frame update
    void Start()
    {
        if (!m_SpawnPosition)
            m_SpawnPosition = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_enemyRb2d = Instantiate(m_enemy, m_SpawnPosition.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            m_enemyRb2d.velocity = new Vector2(x, y) * m_SpawnVelocity;
            Destroy(this.gameObject);
        }
    }
}
