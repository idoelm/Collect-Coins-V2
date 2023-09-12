using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    //[SerializeField] private float speed = 5f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float currentHealth;
    private float heart = 4f;
    public AudioSource audioHeart;
    public AudioSource audioBackground;
    public TextMeshProUGUI scoreText;
    private int Score = 0;
    private bool IsGrounded = true;
    private Rigidbody2D rigidBody;
    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;
    void Start()
    {
        audioBackground.Play();
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            Debug.LogError($"Failed to start. {rigidBody.GetType()} not found!");
        }
        scoreText.text = "Score " + Score;
        currentHealth = maxHealth;
       
    }
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();

        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
        if (collision.gameObject.tag.Equals("Coin"))
        {
            Destroy(collision.gameObject);
            Score++;
            Debug.Log(Score);
            scoreText.text = "Score " + Score;
        }
        if (collision.gameObject.tag.Equals("Cup"))
        {
            SceneManager.LoadScene("Victory");
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            currentHealth -= 1;
        }
        if (collision.gameObject.tag == "Heart")
        {
            Debug.Log("Heart");
            audioBackground.volume = 0f;
            Invoke("UpVolumeAudioBackground", 18);
            audioHeart.volume = 8f;
            audioHeart.Play();
            if (currentHealth + heart >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += heart;
            }
            Destroy(collision.gameObject);
        }
    }
    public float GetMaxHealth()
    { 
        return this.maxHealth;
    }
    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public void UpVolumeAudioBackground()
    {
        audioBackground.volume = 0.9f;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded)
        {
            IsGrounded = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpingPower);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

}
