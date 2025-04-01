using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    
    private Vector2 movement;

    public Rigidbody2D rb;
    public Camera roomCamera;
    public Animator animator;

    public AudioSource SFXPlayer;
    public AudioSource Footstep;
    public AudioClip uiSFX;
    public AudioClip doorSFX;

    //public Animator anim;
    //public bool interactingWithScreen;

    //void Awake()
    //{
    //    anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    //    rb = GetComponent<Rigidbody2D>();
    //    gameObject.SetActive(true);
    //}

    private void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("RoomPlayerX"), PlayerPrefs.GetFloat("RoomPlayerY"), PlayerPrefs.GetFloat("RoomPlayerZ"));
        roomCamera.transform.position = new Vector3(PlayerPrefs.GetFloat("RoomCameraLocationX"), PlayerPrefs.GetFloat("RoomCameraLocationY"), PlayerPrefs.GetFloat("RoomCameraLocationZ"));
        SFXPlayer.PlayOneShot(doorSFX);

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.sqrMagnitude >= 1f)
        {
            if (!Footstep.isPlaying)
            {
                Footstep.Play();
            }
        } else
        {
            Footstep.Stop();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SFXPlayer.PlayOneShot(uiSFX);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

}
