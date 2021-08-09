using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;

    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the player on the map
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        //check how close player is to the current point
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f) // get the distance between 2 objects
        {

            //when player inputs direction check if the map has that point
            if (Input.GetAxisRaw("Horizontal") > .5f) //Input right
            {
                if (currentPoint.right != null) // if the current point is not empty
                {
                    SetNextPoint(currentPoint.right);
                }
            }

            else if (Input.GetAxisRaw("Horizontal") < -.5f) //Input left
            {
                if (currentPoint.left != null) // if the current point is not empty
                {
                    SetNextPoint(currentPoint.left);
                }
            }

            else if (Input.GetAxisRaw("Vertical") > .5f) //Input up
            {
                if (currentPoint.up != null) // if the current point is not empty
                {
                    SetNextPoint(currentPoint.up);
                }
            }

            else if (Input.GetAxisRaw("Vertical") < -.5f) //Input down
            {
                if (currentPoint.down != null) // if the current point is not empty
                {
                    SetNextPoint(currentPoint.down);
                }
            }
        }
    }

    public void  SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint; // set current point to next point
    }
}
