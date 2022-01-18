using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kal : MonoBehaviour
{
    //variables
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator animate;

    //serialized fields
    [SerializeField] private LayerMask ground;
    [SerializeField] private float jumpSpeed = 5f;

    //for jumping
    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;
    bool isJumping;

    public GameManager gameManager;

    //FSM (what do these even do again??)
    private enum State {running, jumping, falling}
    private State currentState = State.running;

    //Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<Collider2D>();
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); //to move it lol
        AnimationState();
        animate.SetInteger("state", (int)currentState); //SETTING THE FREAKING STATE!!!
    }

    private void Movement()
    {
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            isJumping = true;
            currentState = State.jumping;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpSpeed;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpSpeed;
                jumpTimeCounter = jumpTimeCounter - Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstacle")
        {
            gameManager.GameOver();
        }
    }

    private void AnimationState()
    {
        if (currentState == State.jumping)
        {
            if (rb.velocity.y < 0.1f)
            {
                currentState = State.falling;
            }
        }
        else if (currentState == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                currentState = State.running;
            }
        }
        else
        {
            currentState = State.running;
        }
    }

}
