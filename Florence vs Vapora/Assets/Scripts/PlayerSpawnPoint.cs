using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    void Start()
    {
        //at the start of the scene, it finds the player and sets its spawn to this spawn point
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UpdatePlayerSpawnLocation(this.gameObject);
    }

}
