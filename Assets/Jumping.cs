using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public int playerSpeed = 5;
    public Rigidbody2D myRB;
    public float jumpPower;
    private JumpingController currentJumpState;

  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentJumpState != JumpingController.DoubleJump)
            Jump();

        myRB.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal"), 0f,
        Input.GetAxis("Vertical")) * Time.fixedDeltaTime * playerSpeed);
    }


    private void Jump()
    {
        myRB.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode2D.Impulse);



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
        if (collision.gameObject.tag == "floor")
            currentJumpState = JumpingController.Ground;
    }
}

enum JumpingController
{
    Ground = 0,
    FirstJump = 1,
    DoubleJump = 2,

}

