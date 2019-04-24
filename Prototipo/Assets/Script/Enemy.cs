using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("PlayerProjectile"))
        {
            Destroy(obj);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ball")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.name == "Spike")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
