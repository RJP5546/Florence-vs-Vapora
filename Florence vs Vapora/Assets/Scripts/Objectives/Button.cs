using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private SlidingDoor slidingDoor;
    private Vector2 startingPos;
    private Vector2 pressedPos;

    private void Start()
    {
        startingPos = this.transform.position;
        pressedPos = new Vector2(transform.position.x, transform.position.y - 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        slidingDoor.StopAllCoroutines();
        slidingDoor.StartCoroutine("OpenDoor");
        StopAllCoroutines();
        StartCoroutine("PressButton");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        slidingDoor.StopAllCoroutines();
        slidingDoor.StartCoroutine("CloseDoor");
        StopAllCoroutines();
        StartCoroutine("ReleaseButton");
    }

    IEnumerator PressButton()
    {
        while (Vector2.Distance(transform.position, pressedPos) > .01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, pressedPos, 2 * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

    }
    IEnumerator ReleaseButton()
    {
        while (Vector2.Distance(transform.position, startingPos) > .01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPos, 2 * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

}
