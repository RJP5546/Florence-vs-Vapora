using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class ItemInteraction : MonoBehaviour
{
    public UnityEvent Interaction;

    public void InvokeEvent()
    {
        Interaction.Invoke();
    }
}
