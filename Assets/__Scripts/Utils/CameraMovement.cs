using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Camera cam;
    private float yMoveDist;
    private float xMoveDist;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        yMoveDist = cam.orthographicSize / 2;
        xMoveDist = Mathf.Floor(yMoveDist * cam.aspect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///<summary>
    ///Tells the camera where to move
    ///</summary>
    ///<param name="direction">Integer Vector2 to move camera along grid</param>
    void Move(Vector2 direction)
    {
        transform.position = new Vector2(direction.x * xMoveDist, direction.y * yMoveDist);
    }
}
