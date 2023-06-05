using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject target;
    public float TimeInterval = 0f;





    public void fire()
    {
        var bullet_ = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet_.transform.SetParent(transform);
        var direction = (target.transform.position - transform.position).normalized;
        bullet_.GetComponent<Rigidbody2D>().AddForce(direction * 80);
    }
}
