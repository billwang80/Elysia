using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private float moveInputY;
    public bool dashing = false; 

    private Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput > 0)
            spriteRenderer.flipX = true;
        if (moveInput < 0)
            spriteRenderer.flipX = false;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);
    }
    private bool isDashed()
    {
        if (!dashing)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            moveInputY = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.W))
            {
                rigidBody.velocity = new Vector2(0, 10);
                return true; 
            }
            return false;
        }
        else { return false; }
    }
}
