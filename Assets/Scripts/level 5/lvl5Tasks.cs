using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl5Tasks : MonoBehaviour
{
    public List<GameObject> buttons;
    public Chain chainScript;
    public GameObject Boulder;
    public GameObject lastLink;
    public static bool goUp = false;
    public static bool goDown = false;
    public globals globals;
    public GameObject lightning;


    private void Start()
    {
        
    }
    private void Update()
    {
        if (goDown)
        {
            chainScript.chainMakeMode = true;
        }

        else if (goUp || Input.GetKey(KeyCode.U) )
        {
            
            chainScript.chainMakeMode = true;
            var direction = (-Boulder.transform.position + lastLink.transform.position).normalized;
            Boulder.transform.position += direction*0.08f;
            Debug.Log(direction);
        }
        else
        {
            chainScript.chainMakeMode = false;
        }
    }
    public void resetButtons()
    {
        StartCoroutine(resetButtonsToNormalPosition());
    }


    IEnumerator resetButtonsToNormalPosition()
    {
        yield return new WaitForSeconds(2);
        foreach (var button in buttons)
        {
            Debug.Log("trying to get script");
            var script = button.GetComponent<puzzleButtonScript>();
            if (script == null) { yield return null; }
            script.release();
            Debug.Log("found it and called the function!");
        }
    }
}
