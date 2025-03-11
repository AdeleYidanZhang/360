using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerMovement : MonoBehaviour
{

    private float speed = 288f; 
    private Vector2 movement; 
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);

    }

    public void Move(InputAction.CallbackContext context)
    {

        animator.SetBool("isWalking", true);

        if(context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", movement.x);
            animator.SetFloat("LastInputY", movement.x);
        }

        movement = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);
    }

}
