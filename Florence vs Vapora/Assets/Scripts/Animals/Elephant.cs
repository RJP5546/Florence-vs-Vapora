using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant : Animal
{
    public Transform[] FlightPath;
    public float flySpeed = 5f;

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


        yield return new WaitForSecondsRealtime(.5f);

        for (int positionIndex = 0; positionIndex < FlightPath.Length; positionIndex++)
        {
            Debug.Log("index val: " + positionIndex);
            while (Vector2.Distance(transform.position, FlightPath[positionIndex].position) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, FlightPath[positionIndex].position, flySpeed * Time.deltaTime);
                yield return null;
            }
        }



        Debug.Log("flight finished");

    }
}
