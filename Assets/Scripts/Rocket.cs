using System;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] int speed = 30;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("RightWall") || collision.gameObject.tag.Equals("leftWall") ||
            collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Heart"))
        {
            Destroy(gameObject);
        }
    }

}
