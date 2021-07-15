using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;  //advaned way to find PlayerHealtController in other scripts

    public int currentHealth;
    public int maxHealth;

    //activates before void start connected to public static PlayerHealthController instance;
    private void Awake()
    {
        instance = this;
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
        
    }

    //Create own custom function
    public void DealDamage()
    {
        //currentHealth = currentHealth - 1; long way
        //currentHealth -= 1;
        currentHealth--; //shorter way to do it -- means take away 1, ++ means add 1

        //check what will happen when the player has no health
        if(currentHealth <= 0)
        {
            //remove the player game object from the game
            gameObject.SetActive(false);
        }
    }
}
