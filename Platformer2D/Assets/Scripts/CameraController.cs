using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables
    public Transform target;
    public Transform farBackground;
    public Transform middleBackground;
    private float lastXPosition;
    public float minHeight;
    public float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        //give first value
        lastXPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //....move the position of the camera on the x and y axis

        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //....create a float and math function to take in 3 different values

        //float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        //transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        //shorten code above
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        //How much the camera is moving each frame
        float distanceToMovex = transform.position.x - lastXPosition;

        farBackground.position = farBackground.position + new Vector3(distanceToMovex, 0f, 0f);
        middleBackground.position = middleBackground.position + new Vector3(distanceToMovex * .5f, 0f, 0f);
      //middleBackground.position += new Vector3()  ... short cut

        lastXPosition = transform.position.x;
    }
}
