using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator : Animal
{
    [SerializeField] private Transform[] WalkPath;
    [SerializeField] private float walkSpeed = 5f;

    private bool ranInteractionEvent;

    public new void Start()
    {
        base.Start();
        //Disable boar box Collider
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    public void RunInteraction()
    {
        if (isHealed)
        {
            if (ranInteractionEvent) { return; }
            StartCoroutine(Walk());
        }
        else
        {
            potion.HealAnimal(this);
        }
    }

    IEnumerator Walk()
    {
        for (int positionIndex = 0; positionIndex < WalkPath.Length; positionIndex++)
        {
            if (transform.position.x - WalkPath[positionIndex].position.x > 0) { spriteRenderer.flipX = true; }
            else { spriteRenderer.flipX = false; }

            while (Vector2.Distance(transform.position, WalkPath[positionIndex].position) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, WalkPath[positionIndex].position, walkSpeed * Time.deltaTime);
                yield return null;
            }
        }

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = true;
        ranInteractionEvent = true;
    }
}
