using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownPlayerMovement : MonoBehaviour
{

    public float moveSpeed = 288f; 
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    private Vector3 respawnPoint;

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        respawnPoint = transform.position;

    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//in the build settings, there is index for each scenes;
            respawnPoint = transform.position;//Update the respawn point in the scene;
        }
        else if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//For specific index number of that scene -> use SceneManager.LoadScene(index number(like 0));
            respawnPoint = transform.position;
        }
    }

}
