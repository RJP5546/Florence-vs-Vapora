using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        //at the start of the scene, it finds the player and sets its spawn to this spawn point
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().UpdatePlayerSpawnLocation(this.gameObject);
        player.transform.position = this.transform.position;
    }

}
