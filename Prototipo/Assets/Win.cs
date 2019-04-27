using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
    private GameObject menuManager;
    private void Awake()
    {
        menuManager = GameObject.Find("MenuManager");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            menuManager.GetComponent<MenuManager>().winState = true;
        }
    }
}