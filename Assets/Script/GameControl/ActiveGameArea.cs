using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameArea : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameController.instance.SetPlayerLives(0);
        }
        else
            Destroy(collision.gameObject);
    }
}
