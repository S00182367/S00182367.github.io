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

                if(hurtCounter > 0)
                {
                    hurtCounter -= Time.deltaTime;

                    if(hurtCounter < 0)
                    {
                        currentState = bossStates.moving;
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
