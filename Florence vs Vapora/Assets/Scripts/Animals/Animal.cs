using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Animal : MonoBehaviour
{
    // Boolean to check if an animal can be Healed
    protected bool isHealed = false;
    private SpriteRenderer spriteRenderer;

    protected GameObject player;
    protected HealingPotion potion;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        potion = player.GetComponent<HealingPotion>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.blue;
    }

    public void Heal()
    {
        isHealed = true;
        spriteRenderer.color = Color.green;
    }
}
