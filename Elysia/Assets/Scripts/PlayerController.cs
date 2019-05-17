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

    private int numberOfDashes;
    public int extraDashValue;

    // Start is called before the first frame update
    void Start()
    {
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
            spriteRenderer.flipX = true;
        if (moveInput < 0)
            spriteRenderer.flipX = false;
        isDashed();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);
        // 
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
}
