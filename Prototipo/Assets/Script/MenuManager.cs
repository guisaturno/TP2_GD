using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    private bool pauseState = true;
    public int timeMode;
    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Application.Quit();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }

    private void Pause()
    {
        timeMode = GameObject.Find("Player").GetComponent<PlayerController>().timeMode;
        if (pauseState == true)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            pauseState = false;
            if (timeMode == 0)
            {
                Time.timeScale = 1f;
            }
            else if (timeMode == 1)
            {
                Time.timeScale = 0.5f;
            }
            else if (timeMode == 2)
            {
                Time.timeScale = 1.5f;
            }
            
        }
        else if(pauseState == false)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            pauseState = true;
            Time.timeScale = 0f;
        }       
    }
}
