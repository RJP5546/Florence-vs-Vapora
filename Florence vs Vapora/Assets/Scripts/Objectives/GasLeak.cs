using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasLeak : MonoBehaviour
{
    //this is for demo purposes only and will be changed later
    [SerializeField] private LevelExit levelExit;

    public void RunInteraction()
    {
        StartCoroutine(InteractionCoroutine());
    }
    IEnumerator InteractionCoroutine()
    {
        GetComponentInChildren<ParticleSystem>(true).loop = false;
        yield return new WaitForSecondsRealtime(5f);
        levelExit.GetComponent<SpriteRenderer>().color = Color.green;
        levelExit.canExit = true;
        Destroy(gameObject);
    }
}
