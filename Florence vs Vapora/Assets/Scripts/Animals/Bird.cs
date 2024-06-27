using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal
{
    public Transform position;
    public float flySpeed = 5f;

    [SerializeField] private Transform playerSeatPos;
    private float gScale;

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
        Debug.Log("Flight Started");

        LockPlayerOn();

        yield return new WaitForSecondsRealtime(.5f);

        while (Vector2.Distance(transform.position, position.position) > .1f)
        {
            transform.position = Vector2.Lerp(transform.position, position.position, flySpeed * Time.deltaTime);
            yield return null;
        }
        Debug.Log("flight finished");

        LockPlayerOff();
    }

    private void LockPlayerOn()
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        player.transform.position = playerSeatPos.position;
        player.transform.SetParent(transform);
    }

    private void LockPlayerOff()
    {
        player.transform.parent = null;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
    }
}
