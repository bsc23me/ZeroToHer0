using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [SerializeField] private float movementSpeed = 10f;

    public void Move(Vector3 direction)
    {
        //transform.position += direction * movementSpeed;
        Move(new Vector2(direction.x, direction.y));
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction * movementSpeed;
    }

}
