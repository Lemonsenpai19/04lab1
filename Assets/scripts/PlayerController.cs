using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float jumpForce = 7f; // Jump strength
    private bool isGrounded = true; // Check if the player is on the ground
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle horizontal movement
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right keys

        // Apply movement
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Jump when pressing W and the player is grounded
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // The player is now in the air
        }
    }

    // Detect collisions to check if the player is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is grounded again
        }
    }
}
