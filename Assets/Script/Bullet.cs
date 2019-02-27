﻿using System.Collections;
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
    private Vector2 currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime += Time.time;
        render = GetComponent<SpriteRenderer>();
        m_rdg = GetComponent<Rigidbody2D>();
        if (target != null)
        {
            Debug.Log("Not null");
            currentDirection = (target.transform.position - transform.position);
            //m_rdg.velocity = currentDirection * speed;
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (Time.time > lifeTime)
            Destroy(gameObject);
        m_rdg.AddForce(currentDirection);

    }
    public void SetTarget(GameObject Target)
    {
        Debug.Log("set target");
        target = Target;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            Debug.Log("dis player");
            Destroy(target);
        }
    }
}