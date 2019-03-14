using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public AudioClip JumpClip;
    public AudioSource JumpSource;


    // Start is called before the first frame update
    void Start()
    {
        JumpSource.clip = JumpClip;
    }

    // Update is called once per frame
    void Update()
    {
        //if (PlayerScript.is jump)
        {
            JumpSource.Play();
        }
    }
}
