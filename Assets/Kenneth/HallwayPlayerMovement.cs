using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class HallwayPlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    private bool isFacingRight = false;
    public Rigidbody2D rb;
    public Animator anim;
    public Camera hallwayCamera;

    public AudioSource SFXPlayer;
    public AudioSource footsteps;
    public AudioClip uiSFX;
    public AudioClip doorSFX;

    private void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("HallPlayerX"), PlayerPrefs.GetFloat("HallPlayerY"), PlayerPrefs.GetFloat("HallPlayerZ"));
        hallwayCamera.transform.position = new Vector3(PlayerPrefs.GetFloat("HallCameraLocationX"), PlayerPrefs.GetFloat("HallCameraLocationY"), PlayerPrefs.GetFloat("HallCameraLocationZ"));
        SFXPlayer.PlayOneShot(doorSFX);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

        if (PlayerPrefs.GetInt("DirectionCoordiator") == 1 || PlayerPrefs.GetInt("DirectionCoordiator") == 3)
        {
            horizontal = Input.GetAxisRaw("Vertical");
        }

        if (PlayerPrefs.GetInt("DirectionCoordiator") == 2 || PlayerPrefs.GetInt("DirectionCoordiator") == 4)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        Flip();



        if (rb.velocity.x >= 1f)
        {
            if (!footsteps.isPlaying)
            {
                footsteps.Play();
            }
        }
        else
        {

            footsteps.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SFXPlayer.PlayOneShot(uiSFX);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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
