using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer thePlayer;

    private MapPoint[] allPoints;

    // Start is called before the first frame update
    void Start()
    {
        allPoints = FindObjectsOfType<MapPoint>();

        // loop through to find same level to load as in player prefs
        if(PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach(MapPoint point in allPoints)
            {
                if(point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position; //move player to that point
                    thePlayer.currentPoint = point; //assign players current point as the new point
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //set up corouting
    public void Loadlevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        //play sound effect
        AudioManager.instance.PlaySFX(4);

        //add fadeing 
        LSUIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / LSUIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad); //load the point the player is on
    }
}
