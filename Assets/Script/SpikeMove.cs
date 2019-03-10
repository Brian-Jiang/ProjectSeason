using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    [SerializeField] public float att_frq;
    [SerializeField] public float att_time;
    [SerializeField] public float start_time;
    private float next_att;
    [SerializeField] public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(next_att);
        next_att = start_time;
        Debug.Log(next_att);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time>=next_att)
        {
            //Debug.Log(Time.time);
            //Debug.Log("act");
            Debug.Log(next_att);
            Debug.Log(Time.time);
            spike.SetActive(true);
           
        }
        if (Time.time >= (next_att + att_time))
        {
            //Debug.Log("NO act");
            spike.SetActive(false);
            next_att = Time.time + att_frq;
            Debug.Log(next_att);
            Debug.Log(Time.time);
        }
        
    }
    /**private void Shows()
    {
        spike.SetActive(true);
        if(Time.time >= (next_att+att_time))
        {
            spike.SetActive(false);
        }
        next_att = Time.time + att_frq;
    }*/
   
}
