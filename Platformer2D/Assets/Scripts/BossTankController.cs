using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossStates { shooting, hurt, moving, ended };
    public bossStates currentState;

    public Transform theBoss;
    public Animator anim;

    [Header("Movement")] //Headers make navigation in unity easier
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;
    public GameObject mine;
    public Transform minePoint;
    public float timeBetweenMines;
    private float mineCounter;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;
    public GameObject hitBox;

    [Header("Health")]
    public int health = 5;
    public GameObject explosion, winPlatform;
    private bool isDefeated;
    public float shotSpeedUp, mineSpeedUp;

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
            case bossStates.shooting:

                shotCounter -= Time.deltaTime;

                if(shotCounter <=0) // shoot bullet
                {
                    shotCounter = timeBetweenShots;

                    var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = theBoss.localScale;
                }

                break;

            case bossStates.hurt:

                if(hurtCounter > 0) //Hurt Boss
                {
                    hurtCounter -= Time.deltaTime;

                    if(hurtCounter < 0)
                    {
                        currentState = bossStates.moving;

                        mineCounter = 0;

                        if(isDefeated)
                        {
                            theBoss.gameObject.SetActive(false);
                            Instantiate(explosion, theBoss.position, theBoss.rotation);

                            winPlatform.SetActive(true);

                            AudioManager.instance.StopBossMusic();

                            currentState = bossStates.ended;
                        }
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

                        EndMovement(); //call end movement function
                    }
                }
                else
                {
                    theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x < leftPoint.position.x)//Move Boss left
                    {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);//flip boss 

                        moveRight = true;

                        EndMovement(); //call end movement function
                    }
                }

                mineCounter -= Time.deltaTime;

                if(mineCounter <= 0)
                {
                    mineCounter = timeBetweenMines;

                    Instantiate(mine, minePoint.position, minePoint.rotation);
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

    public void TakeHit() //boss takes a hit function
    {
        currentState = bossStates.hurt;
        hurtCounter = hurtTime;

        anim.SetTrigger("Hit");

        AudioManager.instance.PlaySFX(0);

        BossTankMine[] mines = FindObjectsOfType<BossTankMine>();
        if(mines.Length > 0)
        {
            foreach(BossTankMine foundMine in mines)
            {
                foundMine.Explode(); // call on explode function
            }
        }

        health--;

        if(health <= 0)
        {
            isDefeated = true;
        }
        else
        {
            timeBetweenShots /= shotSpeedUp;// speed up when hit
            timeBetweenMines /= mineSpeedUp;// speed up when hit
        }
    }

    private void EndMovement() //stop boss movement function
    {
        currentState = bossStates.shooting;

        shotCounter = 0f;

        anim.SetTrigger("StopMoving");

        hitBox.SetActive(true);
    }
}
