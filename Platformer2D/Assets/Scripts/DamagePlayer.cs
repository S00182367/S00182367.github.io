using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //new function
    private void OnTriggerEnter2D(Collider2D other)
    {
        //check to see what object is interacting
        if (other.tag == "Player")  // == ask question = assign
        {

            //use debug to test out if things are working properly
            //Debug.Log("Hit");

            //find the controller and function
            //less advanced way of finding as must search through all objects
            //FindObjectOfType<PlayerHealthController>().DealDamage(); 

            // the instance on the PlayerHealthController reduces search looks in unity memory
            PlayerHealthController.instance.DealDamage();
        }
    }
}
