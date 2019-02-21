using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            //freeze rig
        }
        else if (collision.CompareTag("Vine"))
        {
            //move up or down bu W&S
            //inst 2 coillders to stop the player to go out off the vine?
        }
    }
}
