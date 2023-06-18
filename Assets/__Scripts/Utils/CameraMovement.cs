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
        // Automatically calculate distance to move cam based on size
        yMoveDist = cam.orthographicSize * 2;
        xMoveDist = Mathf.Ceil(yMoveDist * cam.aspect);
    }

    ///<summary>
    ///Tells the camera where to move
    ///</summary>
    ///<param name="direction">Integer Vector2 to move camera along grid</param>
    public void Move(Vector2 direction)
    {
        transform.position += new Vector3(direction.x * xMoveDist, direction.y * yMoveDist);
    }
}
