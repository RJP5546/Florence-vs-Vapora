using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    private Health health;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && health == null)
        {
            health = collision.GetComponent<Health>();
            health.TakeDamage(1);
        }
        else if (collision.gameObject.tag == "Player" && health != null)
        {
            health.TakeDamage(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        health = null;
    }
}
