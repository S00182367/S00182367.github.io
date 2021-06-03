using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anima;
    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>(); //Animate the component
        theSR = GetComponent<SpriteRenderer>(); //Get the sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        //GetAxisRaw If not pressed will be zero if preesed will be 1 / -1 will leave as GetAxis for moment

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        // Stops the player from doing jumps all the time

        if(isGrounded) //If the player is on the ground they can do a second jump
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded) //Check if player is on the ground
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                if(canDoubleJump) //Allow the player to do a double jump
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }

        if(theRB.velocity.x < 0)
        {
            theSR.flipX = true; //flip the player
        }
        else if(theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }

        anima.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x)); //Animate the run MathF.Abs turns the number positive
        anima.SetBool("isGrounded", isGrounded); //Animate the jump
    }
}
