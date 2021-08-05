using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Make the UI Controller an instance of itself
    public static UIController instance;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite heartFull;
    public Sprite heartEmpty;
    public Sprite heartHalf;

    public Text gemText;

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
        UpdateGemCount(); // update the count at the start of the game
        FadeFromBlack();// fade from black when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFadeToBlack)
        {
            //change the alpha value of the image using math function and move towards
            //start at 0 go to 1 and multiply fade speed by time delta time
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            //Tell when it should stop
            if(fadeScreen.color.a == 1f)
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

    public void UpdateHealthDisplay()
    {
        //Update hearts based on player controolers current health using switch statement
        switch(PlayerHealthController.instance.currentHealth)
        {
            case 6: //player has no damage
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;

            case 5: //player takes half damage
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;

                break;

            case 4: //player takes one damage
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;

                break;

            case 3: //player takes one and half damage
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;

                break;

            case 2: //player takes two damage
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            case 1: //Player takes two and half damage dies
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            case 0: //Player takes three damage dies
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            default: //should by chance the player health go bellow zero 
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

        }
    }

    public void UpdateGemCount()
    {
        //access the text element show gems collected
        gemText.text = LevelManager.instance.gemsCollected.ToString(); // ToString Text is string gemCollected is int convert int to string
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
