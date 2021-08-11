using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        //loop through points so that they have no transform parent
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //make enemy move to current point
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[currentPoint].position) < .05f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }

        if(transform.position.x < points[currentPoint].position.x)
        {
            //filp enemy 
            theSR.flipX = true;
        }
        else if(transform.position.x > points[currentPoint].position.x)
        {
            //flip enemy
            theSR.flipX = false;
        }

    }
}
