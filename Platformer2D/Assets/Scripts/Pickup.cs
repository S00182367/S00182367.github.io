using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem;
    public bool isHeal;

    private bool isCollected;

    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) //are we picking up the gem
    {
        if(other.CompareTag("Player") && !isCollected)// is the player picking it up and is it collected
        {
            if(isGem)// is it the gem that is been picked up
            {
                //go to level manager add 1 to gemscollected
                LevelManager.instance.gemsCollected++;

                isCollected = true; //it has been collected 
                Destroy(gameObject); //Remove the collectable

                //create a new copy of an object using Instantiate, bring to gem position and add rotation
                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCount(); // update the UI
            }

            if(isHeal)
            {
                //Player cant pick up when at full health heal when not at maxHealth
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    //call Heal function 
                    PlayerHealthController.instance.HealPlayer();

                    isCollected = true; //it has been collected
                    Destroy(gameObject); //remove collectable

                    //create a new copy of an object using Instantiate, bring to health position and add rotation
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}
