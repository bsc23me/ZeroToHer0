using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Movement movement;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float fireRate = 0.2f;

    bool canFire;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement.Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        if (Input.GetAxisRaw("Fire1") > 0 && canFire)
            Shoot();
    }

    void Shoot()
    {
        canFire = false;
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.z = 0;
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        Invoke("CanFire", fireRate);
    }

    void CanFire()
    {
        canFire = true;
    }

}
