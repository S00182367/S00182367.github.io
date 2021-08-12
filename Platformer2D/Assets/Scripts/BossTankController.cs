using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossStates { shooting, hurt, moving };
    public bossStates currentState;

    public Transform theBoss;
    public Animator anim;

    [Header("Movement")] //Headers make navigation in unity easier
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;

    // Start is called before the first frame update
    void Start()
    {
        //set current state
        currentState = bossStates.shooting;  //can also say cuaterrentState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //use switch to go through different states
        switch(currentState)
        {
            case bossStates.hurt:

                if(hurtCounter > 0) //Hurt Boss
                {
                    hurtCounter -= Time.deltaTime;

                    if(hurtCounter < 0)
                    {
                        currentState = bossStates.moving;
                    }
                }
                break;

            case bossStates.moving:

                if(moveRight) 
                {
                    theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if(theBoss.position.x > rightPoint.position.x)//Move Boss right
                    {
                        theBoss.localScale = new Vector3(1f, 1f, 1f);//flip boss ...short cut vector3.one

                        moveRight = false;

                        currentState = bossStates.shooting;

                        shotCounter = timeBetweenShots;
                    }
                }
                else
                {
                    theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x < leftPoint.position.x)//Move Boss left
                    {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);//flip boss 

                        moveRight = true;

                        currentState = bossStates.shooting;

                        shotCounter = timeBetweenShots;
                    }
                }

                break;
        }

#if UNITY_EDITOR //will only work within the unity editor

        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
#endif
    }

    public void TakeHit()
    {
        currentState = bossStates.hurt;
        hurtCounter = hurtTime;
    }
}
