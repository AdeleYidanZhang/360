using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

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
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (interactingWithScreen)
        {
            rb.velocity = new Vector2(0f, 0f);
        } else
        {
            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        }

        if ((Input.GetAxisRaw("Horizontal") == 0f) && (Input.GetAxisRaw("Vertical") == 0f))
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("LastInputX", movement.x);
            anim.SetFloat("LastInputY", movement.x);
        } else
        {

            anim.SetBool("isWalking", true);
            anim.SetFloat("InputX", movement.x);
            anim.SetFloat("InputY", movement.y);
        }
    }
}
