using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float xLimit;


    private void Start()
    {
        xLimit = 60f;
    }

    private void Update()
    {
        Debug.Log(xLimit);
        if (transform.localPosition.x > xLimit)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("link"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "boulder")
        {
            Destroy(transform.gameObject);
        }
    }



}
