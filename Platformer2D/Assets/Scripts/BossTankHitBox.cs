using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankHitBox : MonoBehaviour
{
    public BossTankController bossCont;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && PlayerController.instance.transform.position.y > transform.position.y) //hit the boss must hit from above
        {
            bossCont.TakeHit();

            PlayerController.instance.Bounce();

            //turn off hit box when hit
            gameObject.SetActive(false);
        }
    }
}
