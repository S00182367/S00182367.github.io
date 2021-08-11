using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;
    public float distanceToAttackPlayer;
    public float chaseSpeed;
    public float waitAfterAttack;
    private float attackCounter;

    private Vector3 attackTarget;

    public SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        //loop through points so that they have no transform parent
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {
            //if the player is within distance attack if not dont attack
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAttackPlayer)
            {
                attackTarget = Vector3.zero;

                //make enemy move to current point
                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, points[currentPoint].position) < .05f)
                {
                    currentPoint++;

                    if (currentPoint >= points.Length)
                    {
                        currentPoint = 0;
                    }
                }

                if (transform.position.x < points[currentPoint].position.x)
                {
                    //filp enemy 
                    theSR.flipX = true;
                }
                else if (transform.position.x > points[currentPoint].position.x)
                {
                    //flip enemy
                    theSR.flipX = false;
                }
            }
            else
            {
                //attacking player  vector3.zero short cut of writing x 0, y 0, z 0.
                if (attackTarget == Vector3.zero)
                {
                    //set attack target to be equal to player position
                    attackTarget = PlayerController.instance.transform.position;
                }

                //flips enemy to attack again
                if (transform.position.x < PlayerController.instance.transform.position.x)
                {
                    //filp enemy 
                    theSR.flipX = true;
                }
                else if (transform.position.x > PlayerController.instance.transform.position.x)
                {
                    //flip enemy
                    theSR.flipX = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= .1f)
                {
                    //have attacked the player wait after attack
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }
            }
        }
    }    
}
