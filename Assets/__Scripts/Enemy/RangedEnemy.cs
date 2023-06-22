using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float barrelDist = 0.5f;

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        if (canAttack && CanSeePlayer())
            Attack();
    }

    override protected void Attack()
    {
        base.Attack();
        Vector3 target = (player.transform.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, target * barrelDist + transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = target * Constants.bulletSpeed;
    }

}
