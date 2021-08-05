using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //can manage scenes now

public class MainMenu : MonoBehaviour
{
    public string startScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //load startScene
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        //wont show in unity but can run debug to test 
        Application.Quit();

        //Use Debug to test if the game is quitting out
        Debug.Log("Quitting Game");
    }
}
