using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer render;
    private GameObject target;
    private Rigidbody2D m_rdg;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float lifeTime = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        lifeTime += Time.time;
        render = this.GetComponent<SpriteRenderer>();
        m_rdg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lifeTime)
            Destroy(gameObject);
    }
    public void SetTarget(GameObject Target)
    {
        target = Target;
    }
}
