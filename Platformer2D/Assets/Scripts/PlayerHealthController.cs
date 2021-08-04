using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;  //advaned way to find PlayerHealtController in other scripts

    public int currentHealth;
    public int maxHealth;

    public float invincibleLength; //adding invincblity to the player
    private float invincibleCounter;

    private SpriteRenderer theSR;

    public GameObject deathEffect;

    //activates before void start connected to public static PlayerHealthController instance;
    private void Awake()
    {
        instance = this;

        theSR = GetComponent<SpriteRenderer>(); // get the spriterenderer component
    }

    // Start is called before the first frame update
    void Start()
    {
        //when the game starts current healt equals max health
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime; // time to get from 1 frame to next

            if(invincibleCounter <= 0)
            {
                //when invinciblety runs out players color will retun to normal
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    //Create own custom function
    public void DealDamage()
    {
        if (invincibleCounter <= 0) // rest will only happen if invincble counter <= 0
        {

            //currentHealth = currentHealth - 1; long way
            //currentHealth -= 1;
            currentHealth--; //shorter way to do it -- means take away 1, ++ means add 1

            //check what will happen when the player has no health
            if (currentHealth <= 0)
            {
                //if current health should go below zero
                currentHealth = 0; // lowest health can be is zero

                //remove the player game object from the game // move to LevelManager
                // gameObject.SetActive(false);

                //create a new copy of an object using Instantiate, bring to Player position and add rotation
                Instantiate(deathEffect, transform.position, transform.rotation);

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                //setting the invincible counter
                invincibleCounter = invincibleLength;

                //when player takes damage change the color of character to show there in ivincible at that moment
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f); //changes the alpha colour

                PlayerController.instance.KnockBack();

                AudioManager.instance.PlaySFX(9); //play sound effect
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        //currentHealth = maxHealth;  would fully heal the player

        currentHealth++; // add 1 health to current health

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth; //if current health gose above max then it is equal to maxHealth
        }

        //show on the UI what has happened by updating it
        UIController.instance.UpdateHealthDisplay();
    }
}
