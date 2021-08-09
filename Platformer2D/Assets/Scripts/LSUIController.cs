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
}
