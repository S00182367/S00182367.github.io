using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSUIController : MonoBehaviour
{
    public static LSUIController instance;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack;
    private bool shouldFadeFromBlack;

    public GameObject levelInfoPanel;

    public Text levelName;
    public Text gemsFound;
    public Text gemsTarget;
    public Text bestTime;
    public Text timeTarget;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            //change the alpha value of the image using math function and move towards
            //start at 0 go to 1 and multiply fade speed by time delta time
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            //Tell when it should stop
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            //start at 1 go to 0 and multiply fade speed by time delta time
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            //Tell when it should stop
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }

    }

    public void FadeToBlack()
    {
        //activate 1 but make sure the other is deactivated
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        //activate 1 but make sure the other is deactivated
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    //Show level Name
    public void ShowInfo(MapPoint levelInfo)
    {
        //display the level name
        levelName.text = levelInfo.levelName;

        //display gems found and target
        gemsFound.text = "FOUND: " + levelInfo.gemsCollected; //no need to use tostring 
        gemsTarget.text = "IN LEVEL: " + levelInfo.totalGems;

        //Display target time
        timeTarget.text = "TARGET: " + levelInfo.targetTime + "s";

        //display dash if best level time is 0
        if(levelInfo.bestTime == 0)
        {
            bestTime.text = "BEST: ------";
        }
        else
        {
            bestTime.text = "BEST: " + levelInfo.bestTime.ToString("F1") + "s"; //show best time if set in a level Use F1 to display as float num with 1 decimal place
        }

        //activate level info panel
        levelInfoPanel.SetActive(true);
    }

    //Hide level Name
    public void HideInfo()
    {
        //deactivate level info panel
        levelInfoPanel.SetActive(false);
    }
}
