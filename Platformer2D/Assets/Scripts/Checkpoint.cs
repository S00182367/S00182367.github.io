using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;

    public Sprite cpOn;
    public Sprite cpOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) //better for more objects instead of  if(other.tag == "Player"
        {
            CheckpointController.instance.DeactivateCheckpoints();

            theSR.sprite = cpOn; // activate the check point

            //give the spawn point a new value of transform.position
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
        
    }

    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff; // turn off checkpoint
    }
}
