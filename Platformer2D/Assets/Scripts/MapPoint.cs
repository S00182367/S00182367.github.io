using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel;
    public bool isLocked;
    public string levelToLoad;
    public string levelToCheck;

    // Start is called before the first frame update
    void Start()
    {
        //check on a level and is not loaded
        if(isLevel && levelToLoad != null)
        {
            isLocked = true; 

            if(levelToCheck != null)
            {
                // check if there is an int value
                if(PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    // check if equal to one
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                   

                }
 
            }

            if(levelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
