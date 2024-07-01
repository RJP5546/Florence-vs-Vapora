using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private float invulnerabilityTime;
    [SerializeField] private HealthBar healthBar;

    [SerializeField] private UnityEvent Die;

    private bool isInvulnerable;

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
        if (!isInvulnerable)
        {
            //If the health is less than 1, die
            if (health <= 1) { Die.Invoke(); }
            //Set current health after taking damage
            health -= damage;
            healthBar.setHealth(health);
            StartCoroutine(InvulnerableTime());
        }
        
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
    
    //used for when the player dies, reset health to max
    public void ResetHealth()
    {
        health = maxHealth;
        healthBar.setHealth(health);
    }

    IEnumerator InvulnerableTime()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        isInvulnerable = false;
    }

}
