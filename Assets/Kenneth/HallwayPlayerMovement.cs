using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayPlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = false;
    public Rigidbody2D rb;
    public Animator anim;
    public bool interactingWithScreen;

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void FixedUpdate()
    {
        if (!interactingWithScreen)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
