﻿using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    UnityEvent in_water;
    UnityEvent on_vine;
    UnityEvent wind;
    public Rigidbody2D m_rb;
 
    public Vector3 m_rb_vel;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_rb_vel = GetComponent<Rigidbody2D>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        


    }
    void OnTriggerEnter2D(Collider2D collision)//maybe stay2d
    {
        if(collision.CompareTag("Water"))
        {
            m_rb.AddForce(Vector2.down*0.5f);
        }
        else if (collision.CompareTag("Vine"))
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                m_rb.AddForce(Vector2.up * 1f)
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                m_rb.AddForce(Vector2.down * 1f)
            }

            //move up or down bu W&S
            //inst 2 coillders to stop the player to go out off the vine?
        }
        else if(collision.CompareTag("Wind"))
        {

        }
    }
}
