using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal
{
    public Transform[] FlightPath;
    public float flySpeed = 5f;

    [SerializeField] private Transform playerSeatPos;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    private Transform parent;

    private void Awake()
    {
        parent = transform.parent;
    }

    public void RunInteraction()
    {
        if (isHealed)
        {
            StartCoroutine(Fly());
        }
        else
        {
            potion.HealAnimal(this);
        }
    }

    IEnumerator Fly()
    {

        LockPlayerOn();

        AnimalAnimator.SetBool("IsFlying", true);

        yield return new WaitForSecondsRealtime(.5f);

        for (int positionIndex = 0; positionIndex < FlightPath.Length; positionIndex++)
        {
            if (transform.position.x - FlightPath[positionIndex].position.x > 0) 
            {
                spriteRenderer.flipX = true;
                Debug.Log("Player Sprite renderer flip: " + playerSpriteRenderer.flipX + "Bird Sprite renderer flip: " + spriteRenderer.flipX);
                if (playerSpriteRenderer.flipX) { playerSpriteRenderer.flipX = spriteRenderer.flipX; }
            }
            else 
            {
                spriteRenderer.flipX = false;
                Debug.Log("Player Sprite renderer flip: " + playerSpriteRenderer.flipX + "Bird Sprite renderer flip: " + spriteRenderer.flipX);
                if (!playerSpriteRenderer.flipX) { playerSpriteRenderer.flipX = spriteRenderer.flipX; }
            }

            while (Vector2.Distance(transform.position, FlightPath[positionIndex].position) > .01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, FlightPath[positionIndex].position, flySpeed * Time.deltaTime);
                yield return null;
            }
        }
        
        AnimalAnimator.SetBool("IsFlying", false);
        LockPlayerOff();

        yield return new WaitForSecondsRealtime(2f);

        AnimalAnimator.SetBool("IsFlying", true);

        for (int returnPositionIndex = FlightPath.Length - 1; returnPositionIndex >= 0; returnPositionIndex--)
        {
            if (transform.position.x - FlightPath[returnPositionIndex].position.x > 0) { spriteRenderer.flipX = true; }
            else { spriteRenderer.flipX = false; }

            while (Vector2.Distance(transform.position, FlightPath[returnPositionIndex].position) > .01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, FlightPath[returnPositionIndex].position, flySpeed * Time.deltaTime);
                yield return null;
            }
        }
        AnimalAnimator.SetBool("IsFlying", false);


    }

    private void LockPlayerOn()
    {
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        player.GetComponent<PlayerController>().enabled = false;

        player.transform.position = playerSeatPos.position;
        player.transform.SetParent(transform);
    }

    private void LockPlayerOff()
    {
        player.transform.parent = parent;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        rb.gravityScale = 2f;
        player.GetComponent<PlayerController>().enabled = true;
    }
}
