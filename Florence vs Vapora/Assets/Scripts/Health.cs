using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    void Start()
    {
        //Initalize health to max
        health = maxHealth;
    }

    public void TakeDamage()
    {
        //If the health is less than 0, die
        if (health <= 0) { Die(); }
    }

    public void Heal()
    {

    }

    public void Die()
    {

    }
}
