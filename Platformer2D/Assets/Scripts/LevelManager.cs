using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public int gemsCollected;

    public string levelToLoad;

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
        
    }

    //Respawn player function
    public void RespawnPlayer() //use to start coRoutine
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()//coRouting happens outside the game update
    {
        PlayerController.instance.gameObject.SetActive(false);//deactivate player
        AudioManager.instance.PlaySFX(8); //play sound effect

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));//wait 

        UIController.instance.FadeToBlack(); // call on the UI controller

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .2f);//fade to black

        UIController.instance.FadeFromBlack(); //call on the UI controller

        PlayerController.instance.gameObject.SetActive(true);//reactivate player

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint; // reset players position

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth; //tell player healt controller to restore players health

        UIController.instance.UpdateHealthDisplay(); //Update the UI to show hearts refilled
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    //create co routine
    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;//call player controller to stop inputs

        CameraController.instance.stopFollow = true;//call camera controller to stop following

        UIController.instance.levelCompleteText.SetActive(true);//call UI controller to show end level text

        yield return new WaitForSeconds(1.5f);//wait to fade out

        UIController.instance.FadeToBlack(); // call the UI controller

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .25f);//wait for fade to finish 

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1); //store number 1 if true 2 if false using playerPrefs

        SceneManager.LoadScene(levelToLoad);//load into the next level
    }
}
