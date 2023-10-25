using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float direction;
    public float speed;
    public float jumptime;
    public float curentJumpTime;
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
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction, rb.velocity.y);
    }
}
