using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollect : MonoBehaviour
{
    private GameObject player;
    private Inventory inventory;
    //refrence to the last interactable object
    private GameObject interactableObject;
    //a cache of the tag for the last collided with object
    private string tagName;

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
        //Store the tag
        tagName = collision.tag;
        //Switch case path depends on the tags name
        switch (tagName)
        {
            case "health_potion":
                inventory.healthPotion.value += 1;
                Debug.Log("HealthPotions: " + inventory.healthPotion.value);

                Destroy(collision.gameObject);
                break;

            case "interactable_object":
                Debug.Log("Enter Interact Range");
                interactableObject = collision.gameObject;
                break;

            default:
                break;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (tagName)
        {
            case "health_potion":
                break;

            case "interactable_object":
                Debug.Log("Leave Interact Range");
                //remove the ability to interact with the object after the player leaves the range of interaction
                interactableObject = null;
                break;

            default:
                break;
        }
    }

    public void InteractWithItem()
    {
        if (interactableObject != null)
        {
            Debug.Log("Interacted");
        }
        
    }
}
