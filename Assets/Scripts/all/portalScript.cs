using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    public globals globals;
    public GameObject TeleportTo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (globals.isTeleporting) { return; }
        // teleport the gameobject to its related gameobject
        globals.isTeleporting = true;
        collision.transform.position = TeleportTo.transform.position;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(isTeleportingToFalse());
    }
    private IEnumerator isTeleportingToFalse()
    {

        yield return new WaitForSeconds(2f);
        globals.isTeleporting = false;

    }
}
