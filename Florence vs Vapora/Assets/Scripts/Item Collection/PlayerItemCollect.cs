using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollect : MonoBehaviour
{
    private GameObject player;
    private Inventory inventory;

    private void Start()
    {
        player = transform.parent.gameObject;
        inventory = player.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("health_potion"))
        {
            inventory.healthPotion.value += 1;
            Debug.Log("HealthPotions: " + inventory.healthPotion.value);

            Destroy(collision.gameObject);
        }
        */
        string tagName = collision.tag;
        switch (tagName)
        {
            case "health_potion":
                inventory.healthPotion.value += 1;
                Debug.Log("HealthPotions: " + inventory.healthPotion.value);

                Destroy(collision.gameObject);
                break;

            default:
                break;

        }
    }
}
