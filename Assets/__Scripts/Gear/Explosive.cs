using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{

    public float radius;
    public float damage;
    public GameObject ExplosionParticles;

    protected void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);
        for (int i = 0; i < hits.Length; i++)
        {
            try
            {
                hits[i].GetComponent<Health>().Damage(damage / Vector2.Distance(hits[i].transform.position, transform.position));
            } catch { }
        }
        Instantiate(ExplosionParticles,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
