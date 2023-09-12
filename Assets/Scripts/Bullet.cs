using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] int speed = 10;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("RightWall") || collision.gameObject.tag.Equals("leftWall") || collision.gameObject.tag.Equals("Ground") || 
            collision.gameObject.tag.Equals("AddRocket") || collision.gameObject.tag.Equals("Heart"))
        {
            Destroy(gameObject);
        }
    }

}
