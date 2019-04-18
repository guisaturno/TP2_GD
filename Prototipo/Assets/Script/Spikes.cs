using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Rigidbody2D rb;
    RigidbodyConstraints2D rbc;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rbc = gameObject.GetComponent<RigidbodyConstraints2D>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision2D collision2D)
    {
        if (collision2D.gameObject.name == "Bullet")
        {

           //rbc.FreezeRotation;

        }
    }
}
