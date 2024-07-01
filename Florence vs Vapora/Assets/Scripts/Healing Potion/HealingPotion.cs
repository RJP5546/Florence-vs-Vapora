using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Healing Potion script to heal the animals 
 */

public class HealingPotion : MonoBehaviour
{
    [SerializeField] private InventoryIntVariableSO healingPotions;

    public void HealAnimal(Animal animal)
    {
        if (healingPotions.value > 0)
        {
            animal.Heal();
            Debug.Log("healed");
        }
        else
        {
            Debug.Log("Healing Potion Count is 0");
        }
    }
}
