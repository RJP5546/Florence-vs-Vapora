using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    private void Awake()
    {
        Destroy(FindObjectOfType<CoreManager>().gameObject);
    }
}
