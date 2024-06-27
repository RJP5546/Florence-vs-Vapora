using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Animal : MonoBehaviour
{
    // Boolean to check if an animal can be Healed
    protected bool isHealed = false;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.blue;
    }

    public void Heal()
    {
        isHealed = true;
        spriteRenderer.color = Color.green;
    }
}
