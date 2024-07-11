using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerUI : MonoBehaviour
{
    [SerializeField] private InventoryIntVariableSO flowerCount;
    [SerializeField] private TextMeshProUGUI text;
    void Update()
    {
        text.text = "x" + flowerCount.value;
    }
}
