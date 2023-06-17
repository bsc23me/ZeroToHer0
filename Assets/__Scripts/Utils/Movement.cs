using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 10f;

    public void Move(Vector3 direction)
    {
        transform.position += direction * movementSpeed;
    }

}
