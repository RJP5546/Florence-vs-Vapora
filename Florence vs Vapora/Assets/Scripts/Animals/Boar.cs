using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Boar : Animal
{
    [SerializeField] private Vector2 chargeDirection;
    [SerializeField] private float chargeSpeed = 5f;
    [SerializeField] private float speedIncreaseInterval = .5f;
    [SerializeField] private float maxSpeed = 7f;
    private bool hasHitWall = false;

    public void Start()
    {
        base.Start();
        //Disable boar box Collider
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    private void PlayBoarSound()
    {
        FMOD.Studio.EventInstance boar = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Boar");
        boar.start();
        boar.release(); // Releasing the instance helps prevent memory leaks
    }
    //This is a method to directly call in an instance of a FMOD event to play quick SFX before removing it after being called. 

    public void RunInteraction()
    {
        if (isHealed)
        {
            StartCoroutine(Charge(chargeDirection));
            PlayBoarSound();
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
        while (hasHitWall == false)
        {
            if (chargeSpeed < maxSpeed) chargeSpeed += speedIncreaseInterval;

            if (chargeSpeed > maxSpeed) chargeSpeed = maxSpeed;

            transform.position = (Vector2)transform.position + cD * chargeSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
