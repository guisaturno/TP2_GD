using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public BoxCollider2D box;
    public CircleCollider2D circle;

    float ExplosionRadius = 100.0f;
    float ExplosionStrenght = 20000.0f;

    public GameObject explosionPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collider2D collision)
    {

        Projectile projectile = collision.GetComponent<Projectile>();
        Enemy enemy = collision.GetComponent<Enemy>();
        PlayerController player = collision.GetComponent<PlayerController>();



        if(collision.gameObject.name == "Bullet")
        {
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();

            if (rigidbody != null)
            {
                rigidbody.AddForce(ExplosionStrenght * (gameObject.transform.position - transform.position).normalized);
            }
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
        Destroy(enemy.gameObject);
        Destroy(player.gameObject);
    }


}
