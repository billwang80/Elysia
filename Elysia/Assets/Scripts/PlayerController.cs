using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // constants
    private const int DEFAULT_WALL_TIMER = 40;
    private const int DEFAULT_GRAVITY_SCALE = 15;

    // movement physics
    public float speed;
    public float jumpForce;
    private float moveInput;
    private float moveInputY;
    
    private Rigidbody2D rigidBody;

    // sprites and animations
    public SpriteRenderer spriteRenderer;
    public bool facingRight;

    // ground check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // wall checks
    public Transform wallCheckPoint;
    public bool wallCheck;
    public LayerMask wallLayerMask;
    private int wallTimer;
    private bool canClimb;

    // dashing
    private int numberOfDashes;
    public int extraDashValue;
    public bool dashing = false;

    // Start is called before the first frame update
    void Start()
    {
        wallTimer = DEFAULT_WALL_TIMER;
        canClimb = true;
        numberOfDashes = extraDashValue;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.velocity = Vector2.up * jumpForce;
        }

        if (moveInput > 0)
        {
            spriteRenderer.flipX = true;
            facingRight = true;
        }
        if (moveInput < 0)
        {
            spriteRenderer.flipX = false;
            facingRight = false;
        }

        isDashed();

        wallMovement();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);
    }

    private bool isDashed()
    {
        if (!dashing)
        {
           
            if (Input.GetButton("Vertical"))
            {
                
                moveInput = Input.GetAxisRaw("Horizontal");
                moveInputY = Input.GetAxisRaw("Vertical");
                if (Input.GetKeyDown(KeyCode.J))
                {

                    rigidBody.gameObject.transform.position = new Vector2(0, 0);
                    rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
                   // rigidBody.velocity = Vector2.up * 10;
                    //dashing = true;

                }

            }
            
        }
        return false;
    }

    private void wallMovement()
    {
        if (!isGrounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 5f, wallLayerMask);

            if (wallCheck)
            {
                handleWallSliding();
            }
        }
    }

    private void handleWallSliding()
    {
        //rigidBody.gravityScale = 0;
        rigidBody.velocity = Vector2.zero; // new Vector2(rigidBody.velocity.x, -0.0f);
        //rigidBody.gravityScale = DEFAULT_GRAVITY_SCALE;
    }
}
