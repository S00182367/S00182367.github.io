using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;

    public GameObject collectible;

    [Range(0, 100)]public float chanceToDrop; // [Range(0, 100)] has to be within the range of 0 and 100

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //detect if enemy enters trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        //check what we have jumped on
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");

            //deactivate from parent and deactivate
            other.transform.parent.gameObject.SetActive(false);

            //add death effect to the position and rotate
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            //tell the player controller to run the bounce function
            PlayerController.instance.Bounce();

            //pick random number for item to drop
            float dropSelect = Random.Range(0, 100f);

            if(dropSelect <= chanceToDrop)
            {
                //spawn in pickup in position
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
        }
    }
}
