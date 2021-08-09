using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCameraController : MonoBehaviour
{
    public Vector2 minPos;
    public Vector2 maxPos;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() // late update happens after the update is called camera will move after player has moved
    {
        //clamp target position , clamp between 
        float xPos = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
        float yPos = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);

        //tell the camera where to move to
        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
