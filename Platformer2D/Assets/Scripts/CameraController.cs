using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    //Variables
    public Transform target;
    public Transform farBackground;
    public Transform middleBackground;
    //private float lastXPosition;
    public float minHeight;
    public float maxHeight;
    public bool stopFollow;
    private Vector2 lastPos;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //give first value
        //lastXPosition = transform.position.x;
        lastPos = transform.position;
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
        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            //How much the camera is moving each frame
            //float distanceToMoveX = transform.position.x - lastXPosition;
            Vector2 distanceToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            farBackground.position = farBackground.position + new Vector3(distanceToMove.x, distanceToMove.y, 0f);
            //middleBackground.position = middleBackground.position + new Vector3(distanceToMove.x,distanceToMove.y, 0f) * .5f; ....Long way
            middleBackground.position += new Vector3(distanceToMove.x, distanceToMove.y, 0f) * .5f;  //... short cut

            //lastXPosition = transform.position.x;
            lastPos = transform.position;
        }
    }
}
