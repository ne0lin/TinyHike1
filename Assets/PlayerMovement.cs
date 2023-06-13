using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
   // private Animator anim;
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    public int playerSpeed = 5;
    public float jumpPower;
    private JumpingController currentJumpState;


    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
      //  anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal"), 0f,
        Input.GetAxis("Vertical")) * Time.fixedDeltaTime * playerSpeed);
    }

   
    private void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space) && currentJumpState != JumpingController.DoubleJump)
                Jump();
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

        //if (dirX > 0)
        //{
        //    anim.SetBool("running", true);
        // }
        //  else if (dirX < 0) 
        // {
        //    anim.SetBool("running", true);
        //  }
        //  else
        //  {
        //    anim.SetBool("running",false)
        //   }
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode2D.Impulse);



        switch (currentJumpState)
        {
            case JumpingController.Ground:
                currentJumpState = JumpingController.FirstJump;
                break;
            case JumpingController.FirstJump:
                currentJumpState = JumpingController.DoubleJump;
                break;
            case JumpingController.DoubleJump:
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            currentJumpState = JumpingController.Ground;
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
    }
}

enum JumpingController
{
    Ground = 0,
    FirstJump = 1,
    DoubleJump = 2,

}
