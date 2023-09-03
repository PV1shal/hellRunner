using UnityEngine;

public class ManScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public floorSpawner spawner;

    public int jumpTotal = 1;
    private int jumpLeft;

    public float moveSpeed = 5f;

    void Start()
    {
        rigidbody2D.freezeRotation = true;
        jumpLeft = jumpTotal;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool isGrounded = IsGrounded();

        Vector2 velocity = new Vector2(horizontalInput * moveSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = velocity;

        spriteRenderer.flipX = horizontalInput < 0;

        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpLeft > 0)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, moveSpeed);
            jumpLeft--;
        }

        // Animation
        animator.SetBool("running", horizontalInput != 0);
        animator.SetBool("attacking", Input.GetKey(KeyCode.LeftControl));
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null && hit.collider.CompareTag("Ground");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpLeft = jumpTotal;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnTrigger"))
        {
            spawner.createFloor();
        }
    }
}
