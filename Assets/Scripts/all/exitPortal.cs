using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitPortal : MonoBehaviour
{
    public globals globals;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player" && globals.playerHasKey)
        {
            globals.loadNextLevel();
        }
    }
}
