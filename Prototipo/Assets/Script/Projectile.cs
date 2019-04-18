using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeToLive = 5.0f;
    public float timeToLiveTimer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeToLiveTimer += Time.deltaTime;
        if (timeToLiveTimer > timeToLive)
        {
            KillChicken();
        }
    }
    void KillChicken()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("White") || obj.CompareTag("Projectile") || obj.CompareTag("PlayerProjectile"))
        {
            KillChicken();
        }

        if (this.CompareTag("PlayerProjectile"))
        {
            if (obj.CompareTag("Enemy"))
            {
                KillChicken();
            }
        }
    }
}
