using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
                //sets the current interactable object with the obect the player last collided with
                interactableObject = collision.gameObject;
                //toggle interact text on
                interactableObject.GetComponentInChildren<TextMeshPro>(true).gameObject.SetActive(true);
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
                //toggle interact text off
                interactableObject.GetComponentInChildren<TextMeshPro>(true).gameObject.SetActive(false);
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
            interactableObject.GetComponentInChildren<TextMeshPro>(true).gameObject.SetActive(false);
            Debug.Log("Interacted");
            //run the interaction unity event
            interactableObject.GetComponent<ItemInteraction>().InvokeEvent();
        }
        
    }
}
