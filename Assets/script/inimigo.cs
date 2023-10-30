using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;
    bool lado = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (lado)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(velocidade, rb.velocity.y);
        }
        if (!lado)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
            rb.velocity = new Vector2(-velocidade, rb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "parede")
        {
            lado = !lado;
        }
        
    }
    
}
