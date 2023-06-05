using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public bool open = false;
    private float time = 0;
    public float speed;
    private void Update()
    {
        if (open)
        {
            Debug.Log(transform.localPosition);
            if (transform.localPosition.y < 3f )
            {
                time += Time.deltaTime;
                if (time <0.1) { return; }
                time = 0;
                transform.localPosition += new Vector3(0, transform.localPosition.y * speed, 0);
            }
        }
    }
}
