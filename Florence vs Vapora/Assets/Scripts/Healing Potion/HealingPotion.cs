using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Healing Potion script to heal the animals 
 */

public class HealingPotion : MonoBehaviour
{
    [SerializeField] private InventoryIntVariableSO healingPotions;
    [SerializeField] private Sprite[] flowers;

    private SpriteRenderer spriteRender;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = ChooseFlower();
    }

    private Sprite ChooseFlower()
    {
        return flowers[Random.Range(0, flowers.Length + 1)];
    }

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
