using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;

    public float moveSpeed = 10f;

    private bool levelLoading;

    public LSManager theManager;

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
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading) // get the distance between 2 objects and level isent loading
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

            //check if the current point the players is at is a level and that it is not locked
            if(currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
            {
                //if player presses jump botton load into a level
                if(Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;

                    theManager.Loadlevel();
                }
            }
        }
    }

    public void  SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint; // set current point to next point
    }
}
