using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public Transform leftPoint;
    public Transform rightPoint;

    private bool movingRight;

    private Rigidbody2D theRB;

    public SpriteRenderer theSR;
    private Animator anim;

    public float moveTime;
    public float waitTime;

    private float moveCount;
    private float waitCount;

    // Start is called before the first frame update
    void Start()
    {
        //update rigidbody to be on the object
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Remove the parent from the leftPoint and rightPoint
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        //give a value
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            //count down move count
            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                //set move speed and direction
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                //flip the sprite
                theSR.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                //change the direction
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                //flip the sprite
                theSR.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            if (moveCount <= 0)
            {
                //tell wait count to start working and randomise
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }

            anim.SetBool("isMoving", true);
        }
        else if (waitCount > 0)
        {
            //countdown wait count
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if (waitCount <= 0)
            {
                //tell move count to start working and randomise
                moveCount = Random.Range(moveTime * .75f, waitTime * .75f);
            }
            anim.SetBool("isMoving", false);
        }
    }
}
