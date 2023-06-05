using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public enum Direction
{
    up,
    down,
    left,
    right
}
public class arrowScript : MonoBehaviour
{
    [SerializeField]
    Direction direction;

    public GameObject link;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(GetDirection());
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) { return; }
        Vector2 Force = GetDirection();
        if (collision.gameObject.name == "key")
        {
            rb.AddForce(Force * 10);
            Destroy(link);
        }
        else
        {
            rb.AddForce(Force * 1000);
        }
    }

    public Vector2 GetDirection()
    {
        if (direction == Direction.up)
        {
            return Vector2.up;
        }
        else if (direction == Direction.down)
        {
            return Vector2.down;
        }
        else if (direction == Direction.left)
        {
            return Vector2.left;
        }
        else if (direction == Direction.right)
        {
            return Vector2.right;
        }
        return Vector2.zero;
    }
}
