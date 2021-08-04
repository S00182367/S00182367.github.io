using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; //Create instance of player controller

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

    public float knockBackLength;
    public float knockBackForce;
    private float knockBackCounter;

    public float bounceForce;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>(); //Animate the component
        theSR = GetComponent<SpriteRenderer>(); //Get the sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)// all will only happen aslong as knockBackCounter is <= 0
        {

            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
            //GetAxisRaw If not pressed will be zero if preesed will be 1 / -1 will leave as GetAxis for moment

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
            // Stops the player from doing jumps all the time

            if (isGrounded) //If the player is on the ground they can do a second jump
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
                    if (canDoubleJump) //Allow the player to do a double jump
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }
            }

            if (theRB.velocity.x < 0)
            {
                theSR.flipX = true; //flip the player
            }
            else if (theRB.velocity.x > 0)
            {
                theSR.flipX = false;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if(!theSR.flipX) //! means not true
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y); //push back to right
            }
            else
            {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y); //push back to right
            }
        }

        anima.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x)); //Animate the run MathF.Abs turns the number positive
        anima.SetBool("isGrounded", isGrounded); //Animate the jump
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);// show player getting hit

        //activate the KnockBack animation
        anima.SetTrigger("hurt");
    }

    public void Bounce()
    {
        //tell rigidbody to move player up into the air
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
    }
}
