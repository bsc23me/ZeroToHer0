using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        if (canAttack && CanSeePlayer())
        {
            Vector3 target = player.transform.position - transform.position;
            if (target.magnitude > meleeDist)
                movement.Move(target.normalized);
            else
                Attack();
        }
    }

    protected override void Attack()
    {
        base.Attack();
        player.GetComponent<Health>().Damage(damage);
    }
}
