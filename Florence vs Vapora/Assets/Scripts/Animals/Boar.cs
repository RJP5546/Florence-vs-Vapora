using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : Animal
{
    [SerializeField] private Vector2 chargeDirection;
    [SerializeField] private float chargeSpeed = 5f;
    [SerializeField] private float speedIncreaseInterval = .5f;
    [SerializeField] private float maxSpeed = 7f;
    private bool hasHitWall = false;

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
            StartCoroutine(Charge(chargeDirection));
        }
        else
        {
            potion.HealAnimal(this);
            //Enable boar box Collider
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            boxCollider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("breakable_wall"))
        {
            Destroy(collision.gameObject);
            hasHitWall = true;
            
            //Disable boar box Collider
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;
        }
    }

    IEnumerator Charge(Vector2 cD)
    {
        if (cD.x < 0) { this.spriteRenderer.flipX = true; }
        else { this.spriteRenderer.flipX = false; }
        while (hasHitWall == false)
        {
            if (chargeSpeed < maxSpeed) chargeSpeed += speedIncreaseInterval;

            if (chargeSpeed > maxSpeed) chargeSpeed = maxSpeed;

            transform.position = (Vector2)transform.position + cD * chargeSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
