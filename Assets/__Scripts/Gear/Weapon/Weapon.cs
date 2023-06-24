using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    protected float damage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Attack(List<Health> targets)
    {
        foreach(Health h in targets)
            h.Damage(damage);
    }
}
