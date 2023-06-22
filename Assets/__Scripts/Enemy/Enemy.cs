using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement)),RequireComponent(typeof(Health))]
public class Enemy : Subject
{
    protected Movement movement;
    protected GameObject player;
    [SerializeField] protected float meleeDist = 2f;
    [SerializeField] protected float damage = 20f;
    [SerializeField] protected float viewDist = 20f;
    [SerializeField] protected float viewOffset = 1f;

    protected bool canAttack;
    protected float attackRate = 2f;

    // Start is called before the first frame update
    protected void Start()
    {
        canAttack = true;
        movement = GetComponent<Movement>();
        player = GameManager.Instance.Player;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (GetComponent<Health>().Dead)
        {
            NotifyObservers();
            Destroy(gameObject);
        }
    }

    protected virtual void Attack()
    {
            canAttack = false;
            Invoke("CanAttack", attackRate);
    }

    protected bool CanSeePlayer()
    {
        Vector3 target = (player.transform.position - transform.position).normalized;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < viewDist)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + target * viewOffset, target,viewDist,65);
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

    void CanAttack() => canAttack = true;
}
