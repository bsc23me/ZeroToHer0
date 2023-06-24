using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Movement movement;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float attackRate = 0.2f;

    bool canAttack;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        canAttack = true;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        movement.Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized);
        if (Input.GetAxisRaw("Fire1") > 0 && canAttack)
            Shoot();
    }

    // fires a bullet
    // will be abstracted to a separate class gun : weapon
    void Shoot()
    {
        canAttack = false;
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.z = 0;
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        Invoke("CanAttack", attackRate);
    }

    void CanAttack() => canAttack = true;

    void OnBecameInvisible()
    {
        if (cam != null)
        {
            // Camera Movement
            // Initialization
            Vector2 direction = Vector2.zero;
            Vector3 pos = transform.position;
            Vector3 camPos = cam.transform.position;
            // if the player left through the side or top/bottom
            if (Mathf.Abs(pos.x - camPos.x) > Mathf.Abs(pos.y - camPos.y))
                direction.x = Mathf.Sign(pos.x - camPos.x); // move left/right
            else
                direction.y = Mathf.Sign(pos.y - camPos.y); // move up/down
            cam.GetComponent<CameraMovement>().Move(direction);
        }
    }

}
