using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRB;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jump;
    public AudioClip crash;
    private AudioSource playerAudio;
    public float jumpForce;
    public float gravityModifier;
    private bool onGround = true;
    public bool gameOver = false;
    private Animator anim;
    private AudioSource bg;
    private bool doubleJumpUsed;
    public bool doubleSpeed;
   
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>(); 
        bg = GameObject.Find("Main Camera").GetComponent<AudioSource>();
       
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround && gameOver == false) 
        {
            playerRB.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            onGround = false;
            dirt.Stop();
            playerAudio.PlayOneShot(jump,1.0f);
            doubleJumpUsed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !onGround && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jump, 1.0f);

        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            anim.SetFloat("Speed_Multiplier", 2.5f);
        }
        else if(doubleSpeed)
        {
            doubleSpeed = false;
            anim.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirt.Play();
        }
      else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER :( ");
            gameOver = true;
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirt.Stop();
            playerAudio.PlayOneShot(crash, 1.0f);
            bg.Stop();

        }
    }

    
}
