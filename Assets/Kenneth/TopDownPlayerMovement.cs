using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    private float speed = 8f;
    private Vector2 movement;
    private Rigidbody2D rb;
    public Animator anim;
    public bool interactingWithScreen;

    void Awake()
    {
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!interactingWithScreen)
        {
            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        } else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}
