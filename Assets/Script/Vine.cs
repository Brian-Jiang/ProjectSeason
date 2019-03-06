using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    [SerializeField] public float speed;
    public Rigidbody2D vine_force;
    // Start is called before the first frame update
    void Start()
    {
        vine_force = GetComponent<Rigidbody2D>();
        vine_force.AddForce(Vector2.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Stopper"))
        {
            vine_force.velocity = Vector2.zero;
        }
    }
}
