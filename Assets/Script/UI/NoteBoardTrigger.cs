using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBoardTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool NoteAppear = false;
    public GameObject note;

    private void Update()
    {
        //note.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        note.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        note.SetActive(false);
    }



    private void OnTriggerStay(Collider other)
    {
        note.SetActive(true);
    }

}
