using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 14f;
    private float jumpingPower = 18f; 
    float inputHorizontal;
    float inputVertical;

    bool facingRight = true;
    bool facingDown = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    public bool isGravityDown = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            ReverseGravity();
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");

            if (inputHorizontal != 0)
            {
                rb.AddForce(new Vector2(inputHorizontal * speed, 0f));
            }

            if (inputHorizontal > 0 && !facingRight)
            {
                Flip();
            }
            else if (inputHorizontal < 0 && facingRight)
            {
                Flip();
            }
        }

    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.3f, groundLayer);
    }

    void ReverseGravity()
    {

        Debug.Log("Gravity reversed");

        if (isGravityDown == true)
        {
            rb.gravityScale = -1;
        }

        else if (isGravityDown == false)
            rb.gravityScale = 1;

        isGravityDown = !isGravityDown;

        Vector3 OrientationY = gameObject.transform.localScale;
        OrientationY.y *= -1;
        gameObject.transform.localScale = OrientationY;

        facingDown = !facingDown;
    }
}
