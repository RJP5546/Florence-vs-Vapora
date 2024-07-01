using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    //public HealthBar healthBar;
    public Health health;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("On trigger stay");
            health.TakeDamage(1);
        }
    }
}
