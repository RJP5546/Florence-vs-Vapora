using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Fader fader;
    [SerializeField] private Health playerHealth;
    [SerializeField] private PlayerController playerController;


    public void RunRespawn()
    {
        StartCoroutine(Respawn());
    }

    public IEnumerator Respawn()
    {
        Debug.Log("RunRespawn");
        yield return fader.FadeOut();
        playerController.Respawn();
        playerHealth.ResetHealth();
        yield return new WaitForSecondsRealtime(1f);
        yield return fader.FadeIn();
        yield return null;

    }
}
