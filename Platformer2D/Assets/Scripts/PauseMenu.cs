using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect;
    public string mainMenu;

    public GameObject pauseScreen;
    public bool isPaused;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //use keyboard control to pause game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause() //activate and deactivate pause
    { 
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f; //time will run game will play
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f; //no time will pass in the game when paused game will stop
        }
    }

    public void LevelSelect()
    {
        //load level select
        SceneManager.LoadScene(levelSelect);
        //so the game dosent start paused
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        //load main menu
        SceneManager.LoadScene(mainMenu);
        //so the game dosent start paused
        Time.timeScale = 1f;
    }
}
