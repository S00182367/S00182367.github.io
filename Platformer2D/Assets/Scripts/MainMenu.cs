using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //can manage scenes now

public class MainMenu : MonoBehaviour
{
    public string startScene;

    public string continueScene;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(startScene + "_unlocked"))// if the player has played a level
        {
            //show the continue button
            continueButton.SetActive(true);
        }
        else
        {
            //dont show continue button
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //load startScene
        SceneManager.LoadScene(startScene);

        //delete all when starting a new game
        PlayerPrefs.DeleteAll();
    }

    public void ContinueGame()
    {
        //load continue scene
        SceneManager.LoadScene(continueScene);
    }

    public void QuitGame()
    {
        //wont show in unity but can run debug to test 
        Application.Quit();

        //Use Debug to test if the game is quitting out
        Debug.Log("Quitting Game");
    }
}
