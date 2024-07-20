using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SlidingDoor : MonoBehaviour
{
    private Vector2 startingPos;
    [SerializeField] private Transform DoorOpenPos;
    [SerializeField] private float speed = 3f;

    private void Start()
    {
        startingPos = this.transform.position;
    }
    IEnumerator OpenDoor()
    {
        while (Vector2.Distance(transform.position, DoorOpenPos.position) > .01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, DoorOpenPos.position, speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        
    }
    IEnumerator CloseDoor()
    {
        while (Vector2.Distance(transform.position, startingPos) > .01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPos, speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
