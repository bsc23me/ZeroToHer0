using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement)),RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Movement movement;
    private GameObject player;
    [SerializeField] private float meleeDist = 2f;
    [SerializeField] private float meleeDamage = 20f;

    private bool canAttack;
    private float attackRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        movement = GetComponent<Movement>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position - transform.position;
        if (target.magnitude > meleeDist)
            movement.Move(target.normalized * Time.deltaTime);
        else
            Attack();

        if (GetComponent<Health>().Dead)
            Destroy(gameObject);
    }

    void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            player.GetComponent<Health>().Damage(meleeDamage);
            Invoke("CanAttack", attackRate);
        }
    }

    void CanAttack()
    {
        canAttack = true;
    }
}
