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
    public string levelName;

    public int gemsCollected;
    public int totalGems;
    public float bestTime;
    public float targetTime;

    // Start is called before the first frame update
    void Start()
    {
        //check on a level and is not loaded
        if(isLevel && levelToLoad != null)
        {
            if(PlayerPrefs.HasKey(levelToLoad + "_gems")) 
            {
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");
            }

            if(PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

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
