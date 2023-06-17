using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private float health;
    [SerializeField] private float maxHealth = 100f;

    private bool dead;

    public bool Dead { get { return dead; } }

    public float CurrentHealth
    {
        get { return health; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
    }

    private void Start()
    {
        health = MaxHealth;
    }

    public void Damage(float amount)
    {
        health -= amount;
        if (health < 0)
            dead = true;
    }
}
