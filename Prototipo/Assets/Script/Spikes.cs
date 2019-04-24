using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
