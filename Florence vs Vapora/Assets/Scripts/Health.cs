using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    public HealthBar healthBar;

    void Start()
    {
        //Initalize health to max
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    //For debuggin purpose press P to damage player and O to heal player
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Heal(1);
        }
    }

    public void TakeDamage(int damage)
    {
        //If the health is less than 0, die
        if (health <= 0) { Die(); }
        //Set current health after taking damage
        health -= damage;
        healthBar.setHealth(health);
    }

    public void Heal(int heal)
    {
        health += heal;
        //If the health is greater than the max health, set current health to max health
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        healthBar.setHealth(health);
    }

    public void Die()
    {

    }
}
