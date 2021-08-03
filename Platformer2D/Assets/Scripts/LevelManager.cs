using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

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

        yield return new WaitForSeconds(waitToRespawn);//wait 

        PlayerController.instance.gameObject.SetActive(true);//reactivate player

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint; // reset players position

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth; //tell player healt controller to restore players health

        UIController.instance.UpdateHealthDisplay(); //Update the UI to show hearts refilled
    }
}
