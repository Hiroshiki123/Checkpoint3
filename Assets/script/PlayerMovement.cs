using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float direction;
    public float speed;
    public float gravity;
    public float jumptime;
    public float jumpForce;
    public float sensorradius;
    public float variationjump;
    public float curentJumpTime;
    public float jumpForceVariation;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Transform sensor;
    private Animator ani;
    private bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravity;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(sensor.position, sensorradius, 1<<LayerMask.NameToLayer("Ground"));

        direction = Input.GetAxisRaw("Horizontal")*speed;
        if (direction < 0 )
        {
            sr.flipX = true;
        }
        if (direction > 0 )
        {
            sr.flipX = false;
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
            curentJumpTime = jumptime;
            jumpForceVariation = 2;
        }
        else if (Input.GetButton("Jump"))
        {
            curentJumpTime -= Time.deltaTime;
            jumpForceVariation -= Time.deltaTime*1.5f;
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
            rb.velocity = new Vector2(direction, jumpForce * jumpForceVariation) ;
        }
        
    }
}
