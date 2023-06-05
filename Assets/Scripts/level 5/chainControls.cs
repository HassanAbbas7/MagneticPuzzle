using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainControls : MonoBehaviour
{
    public bool goUp;
    public bool goDown;
    public lvl5Tasks lvl5tasks;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lvl5Tasks.goUp = goUp;
        lvl5Tasks.goDown = goDown;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        lvl5Tasks.goUp = false;
        lvl5Tasks.goDown = false;
    }
}
