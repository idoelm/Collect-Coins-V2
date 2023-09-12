using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    Transform tr;
    [SerializeField] float speed = 7f;
    private bool right = true;
    [SerializeField] GameObject playerDead;
    Vector3 LoseScreenPosition = new Vector3(0.0889f, 0.0902f, 0f);
    private int life = 3;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        if(this.life <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            //  Debug.Log("bullet");
            Destroy(collision.gameObject);
            life--;
            this.Start();
        }
        if (collision.gameObject.tag.Equals("Rocket"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            this.speed += 0.3f;
            this.Start();
        }
        if (collision.gameObject.tag.Equals("RightWall"))
        {
            // Debug.Log("RightWall");
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            tr.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (collision.gameObject.tag.Equals("leftWall"))
        {
            // Debug.Log("LeftWall")
            rb.velocity = new Vector2(speed, rb.velocity.y);
            tr.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
