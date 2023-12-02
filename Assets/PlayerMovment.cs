using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float dirX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2 (dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && (rb.position.y <= 0))
            rb.velocity = new Vector3 (rb.velocity.x, 15, 0);
        

        if(dirX < 0)
            sr.flipX = true;
        else sr.flipX = false;
       
    }
}
