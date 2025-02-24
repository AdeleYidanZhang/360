using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class PlayerMovement_Test : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;

    Rigidbody2D rb;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");//able to use AD or left and right key to move;

        FlipSprite();

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        // else if(collision.tag == "NextLevel")
        // {
        //     SceneManagement.LoadScene(SceneManagement.GetActiveScene().buildIndex + 1);
        //     respawnPoint = transform.position;
        // }
        // else if(collision.tag == "PreviousLevel")
        // {
        //      SceneManagement.LoadScene(SceneManagement.GetActiveScene().buildIndex - 1);
        //      respawnPoint = transform.position;
        // }
    }
}
