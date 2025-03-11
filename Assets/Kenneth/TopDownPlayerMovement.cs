using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    
    private Vector2 movement;

    public Rigidbody2D rb;

    public Animator animator;


    //public Animator anim;
    //public bool interactingWithScreen;

    //void Awake()
    //{
    //    anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    //    rb = GetComponent<Rigidbody2D>();
    //    gameObject.SetActive(true);
    //}

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //if (interactingWithScreen)
        //{
        //    rb.velocity = new Vector2(0f, 0f);
        //}
        //else
        //{
        //    rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        //}

        //if ((Input.GetAxisRaw("Horizontal") == 0f) && (Input.GetAxisRaw("Vertical") == 0f))
        //{
        //    anim.SetBool("isWalking", false);
        //    anim.SetFloat("LastInputX", movement.x);
        //    anim.SetFloat("LastInputY", movement.y);
        //} else
        //{

        //    anim.SetBool("isWalking", true);
        //    anim.SetFloat("InputX", movement.x);
        //    anim.SetFloat("InputY", movement.y);
        //}
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

}
