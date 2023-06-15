using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX =0f;
    private SpriteRenderer sprite;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private LayerMask jumpableGround;
    private bool doublejump;


    private enum MovementSate { idle, walking, jumping}
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        respawnPoint = transform.position;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }




    private void Update()
    { 
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doublejump = false;
        }

        if (Input.GetButtonDown ("Jump") && IsGrounded() || doublejump)
        {
            GetComponent<Rigidbody2D>().velocity= new Vector2(rb.velocity.x, jumpForce);

            doublejump =!doublejump;
        }
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        MovementSate state;

        if (dirX > 0)
        {
            state = MovementSate.walking;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementSate.walking;
            sprite.flipX = true;
        }
        else
        {
            state =MovementSate.idle;
        }

        if (rb.velocity.y > 1f)
        {
            state = MovementSate.jumping;
        }

        anim.SetInteger("state", (int) state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down, 1f, jumpableGround);
    }
}



