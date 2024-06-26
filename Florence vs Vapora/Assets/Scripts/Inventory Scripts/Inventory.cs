using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryIntVariableSO healthPotion;

    private void Start()
    {
        healthPotion.value = 0;
    }
}
