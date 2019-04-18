using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
            gameObject.GetComponent<WeaponEnemy>().enabled = true;
    }
    public void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
            gameObject.GetComponent<WeaponEnemy>().enabled = false;
    }

}
