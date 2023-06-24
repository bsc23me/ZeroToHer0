using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWeapon : MeleeWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Attack()
    {
        Vector2 target = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, new Vector2(0.5f, 5f),
            CapsuleDirection2D.Vertical, Mathf.Atan2(target.y, target.x)*Mathf.Rad2Deg,target,0f,
            0b0000000010000001);
        List<Health> targets = new List<Health>();
        foreach (RaycastHit2D hit in hits)
            if (hit.collider.GetComponent<Health>())
                targets.Add(hit.collider.GetComponent<Health>());
        base.Attack(targets);
    }
}
