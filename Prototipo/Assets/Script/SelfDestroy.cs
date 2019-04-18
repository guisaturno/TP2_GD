using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }
}
