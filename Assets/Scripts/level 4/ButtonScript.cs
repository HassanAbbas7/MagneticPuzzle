using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GunScript gs;
    public doorScript ds;
    public bool isGunTrigger;
    public GameObject capsule;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        press();
    }

    void press()
    {
        Debug.Log("pressing");
        capsule.transform.localPosition = new Vector3(0, 0, 0);
        if (isGunTrigger)
        {
            gs.fire();
            StartCoroutine(resetButtonToNormalPosition());
        }
        else
        {
            ds.open = true;
        }
    }

    void release()
    {
        capsule.transform.localPosition = new Vector3(0, 0.51f, 0);
    }


    IEnumerator resetButtonToNormalPosition()
    {
        yield return new WaitForSeconds(2);
        release();
    }

}
