using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{

    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // lifeTime -= Time.deltaTime;  this will destroy the gameobject

        // if(lifeTime < 0)
        // {
        //     Destroy(gameObject);
        // }

        Destroy(gameObject, lifeTime); //shorter way to write the above code will do the same thing
    }
}
