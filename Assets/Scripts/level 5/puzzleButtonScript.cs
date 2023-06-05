using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class puzzleButtonScript : MonoBehaviour
{
    public int number;
    public lvl5Tasks lvl5Tasks;
    public GameObject capsule;
    public globals globals;
    private bool pressed;
    public doorScript door;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        press();
    }


    
    void press()
    {
        if (pressed) { return; }
        pressed = true;
        capsule.transform.localPosition = new Vector3(0, 0, 0);
        globals.code += number.ToString();
        if (globals.code.Length >= 3)
        {
            if (globals.code == "295")
            {
                Debug.Log("success");
                door.open = true;
                globals.refreshVariables();
                globals.getTheKey();
            }
            else
            {
                Debug.Log("failure!");
            }
            globals.code = "";
            lvl5Tasks.resetButtons();
        }
    }

    public void release()
    {

        Debug.Log("releasing");
        pressed = false;
        capsule.transform.localPosition = new Vector3(0, 0.51f, 0);
    }



}
