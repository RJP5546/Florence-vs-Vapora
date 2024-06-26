using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasLeak : MonoBehaviour
{
    public void RunInteraction()
    {
        StartCoroutine(InteractionCoroutine());
    }
    IEnumerator InteractionCoroutine()
    {
        GetComponentInChildren<ParticleSystem>(true).loop = false;
        yield return new WaitForSecondsRealtime(5f);
        Destroy(gameObject);
    }
}
