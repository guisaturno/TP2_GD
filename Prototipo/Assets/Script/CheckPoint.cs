using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    private GameMaster gm;
    public GameObject CheckPointWhite;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.LastCheckPointPos = transform.position;
            CheckPointWhite.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
