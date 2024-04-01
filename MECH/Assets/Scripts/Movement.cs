using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 17f;
    private float jumpingPower = 18f;
    float inputHorizontal;
    float inputVertical;

    bool facingRight = true;
    bool facingDown = true;

    private Rigidbody2D rb;
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

        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E Pressed");
                ReverseGravity();
            }
        }
    }

  //  private void FixedUpdate()
    //{
        //if (Input.GetKeyDown(KeyCode.E))
       // {
        //    Debug.Log("E Pressed");
        //    ReverseGravity();
      //  }
   // }
    

    /* private void FixedUpdate()
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
    */

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
        Vector3 currentScale = gameObject.transform.localScale;
        isGravityDown = !isGravityDown;



        if (isGravityDown == true)
        {
           // horizontal = Input.GetAxisRaw("Horizontal");
            rb.gravityScale = 4;






            gameObject.transform.localScale = new Vector2(currentScale.x, 1);
        }
        else if (isGravityDown == false)
        {
            
            rb.gravityScale = -4;
            // horizontal = -Input.GetAxisRaw("Horizontal");
            //isGravityDown = !isGravityDown;
            facingDown = !facingDown;
            Debug.Log("Upside DOwn");
         


            gameObject.transform.localScale = new Vector2(currentScale.x, -1);
        }


        //currentScale.y *= -1;
        //gameObject.transform.localScale = currentScale;
    }
   

    /*void RevGrav()
    {
        Debug.Log("Gravity reversed");

        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.y *= -1;
        gameObject.transform.localScale = currentScale;


        if (isGravityDown == true)
        {
            // horizontal = Input.GetAxisRaw("Horizontal");
            rb.gravityScale = 4;

            facingDown = !facingDown;
            isGravityDown = !isGravityDown;


        }
        else if (isGravityDown == false)
        {
            rb.gravityScale = -4;
            // horizontal = -Input.GetAxisRaw("Horizontal");
            isGravityDown = !isGravityDown;
            facingDown = !facingDown;
            
        }
    }
    */

}


