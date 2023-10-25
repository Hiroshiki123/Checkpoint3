using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float direction;
    public float speed;
    public float jumptime;
    public float jumpForce;
    public float curentJumpTime;
    public float jumpForceVariation;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal")*speed;
        if (direction < 0 )
        {
            sr.flipX = true;
        }
        if (direction > 0 )
        {
            sr.flipX = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            curentJumpTime = jumptime;
        }
        else if (Input.GetButton("Jump"))
        {
            curentJumpTime -= Time.deltaTime;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            curentJumpTime = 0;
        }
       
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction, rb.velocity.y);

        if (curentJumpTime > 0)
        {
            rb.velocity = new Vector2(direction, jumpForce);
        }
        
    }
}
