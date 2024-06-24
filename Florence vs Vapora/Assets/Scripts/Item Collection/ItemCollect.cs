using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    [SerializeField] private float collectSpeed = 5f;
    
    Transform player = null;

    private void Update()
    {
        if (player != null)
        {
            transform.parent.position = Vector2.Lerp(transform.position, player.position, collectSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
        }
    }
}
