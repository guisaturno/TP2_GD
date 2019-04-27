using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    private bool pauseState = true;
    private bool quitState = false;
    public bool winState = false;
    public int timeMode;

    void Update()
    {
        if (winState == true)
        {
            Win();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Quit();
        }

        if (Input.GetKeyDown(KeyCode.Y) && quitState == true)
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

    private void Quit()
    {
        timeMode = GameObject.Find("Player").GetComponent<PlayerController>().timeMode;
        if (quitState == true)
        {
            transform.GetChild(2).gameObject.SetActive(false);
            quitState = false;
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
        else if (quitState == false)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            quitState = true;
            Time.timeScale = 0f;
        }
    }

    private void Win()
    {
        transform.GetChild(3).gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
