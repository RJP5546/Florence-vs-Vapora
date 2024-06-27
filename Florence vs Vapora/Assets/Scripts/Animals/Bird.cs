using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Animal
{
    public List<Transform> locationPositions = new List<Transform>();
    public float flySpeed = 5f;

    public void RunInteraction()
    {
        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        Debug.Log("Flight Started");
        /*
        int index = 0;
        Vector2 nextPos = locationPositions[0].position;

        while (index < locationPositions.Count)
        {
            Debug.Log(index);
            nextPos = locationPositions[index].position;

            if ((Vector2)transform.position == nextPos)
            {
                index++;
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, nextPos, flySpeed * Time.deltaTime);
            }
        }
        */

        yield return null;
    }
}
