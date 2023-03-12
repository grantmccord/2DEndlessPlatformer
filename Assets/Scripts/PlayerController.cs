using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float distanceToGround = 1.5f;
    public LayerMask whatIsGround;
    private float horizontalInput = 0f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprite;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // so that physics works (doesnt depend on framerate)
    private void FixedUpdate()
    {

        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");

        // Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // rb2d.velocity = movement * speed;




        horizontalInput = Input.GetAxis("Horizontal");
        // dont change y velocity 
        rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);

        UpdateAnimationState();

        Transform feetPos = transform;
        bool isGrounded = Physics2D.Raycast(feetPos.position, Vector2.down, distanceToGround, whatIsGround);

        if (isGrounded && Input.GetAxis("Vertical") > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    public void Update() {

    }

    // Updates running animation
    private void UpdateAnimationState()
    {
        if (horizontalInput > 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
