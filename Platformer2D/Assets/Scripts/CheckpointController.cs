using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance; // create instance of CheckpointController

    private Checkpoint[] checkpoints; //use an array as there are to many objects to be keeping track of when it comes to checkpoints

    public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //find all the checkpoints within the scene when the game starts
        checkpoints = FindObjectsOfType<Checkpoint>();

        //spawn player where they are at the start of the level
        spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateCheckpoints()//activate current checkpoint and deactivate older checkpoint
    {
        for(int i = 0; i < checkpoints.Length; i++)// start at 0, check lenghth of array, add 1 to i until i < is exceeded
        {
            checkpoints[i].ResetCheckpoint(); //checkpoints at position i run function
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint) //create variable to be only useed in this function
    {
        //Spawn point that we have stored will be equal to new spawn point
        spawnPoint = newSpawnPoint;
    }
}
