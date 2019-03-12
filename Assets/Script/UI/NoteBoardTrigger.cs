using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBoardTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool NoteAppear = false;
    public GameObject note;
    int count;

    private void Update()
    {
        //note.SetActive(false);
        count++;
        if (count == 600)
        {
            note.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        note.SetActive(true);
        count = 0;

    }

    private void OnTriggerExit2D(Collider other)
    {
        //note.SetActive(false);
    }


}
