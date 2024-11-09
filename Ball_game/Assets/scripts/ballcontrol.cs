using UnityEngine;

public class ballcontrol : MonoBehaviour
{
    public float moveSpeed = 3f;  // Speed at which the ball moves
    public float jumpForce = 5f;   // Force applied when jumping
    private Rigidbody rb;          // Reference to the Rigidbody component

    private bool isGrounded;       // Check if the ball is on the ground

    public GameOverManager gameOverManager; // Reference to the GameOverManager

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement control (Inverted directions fixed)
        float moveHorizontal = -Input.GetAxis("Horizontal"); // Invert Left-Right (A, D, Left Arrow, Right Arrow)
        float moveVertical = -Input.GetAxis("Vertical");     // Invert Forward-Backward (W, S, Up Arrow, Down Arrow)

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * moveSpeed);

        // Jumping (Space key)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Check if the ball is grounded (on the plane)
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // The ball is on the ground
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // The ball is in the air
        }
    }

    // Detect when the ball hits the water (trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            gameOverManager.ShowGameOver(false);  // Trigger Game Over
        }
        else if (other.gameObject.CompareTag("Target"))
        {
            gameOverManager.ShowGameOver(true);   // Trigger Win
        }
    }
}
