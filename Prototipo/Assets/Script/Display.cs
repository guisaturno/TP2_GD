using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    private float time;
    private int mode;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mode = GameObject.Find("Player").GetComponent<PlayerController>().timeMode;
        time = GameObject.Find("Player").GetComponent<PlayerController>().realTime;

        if (Time.timeScale < 1)
        {
            timeDisplay.text = "Slow:" + time.ToString("0.00");
        }
        else if (Time.timeScale > 1)
        {
            timeDisplay.text = "Rapid: " + time.ToString("0.00");
        }
        else if (mode == 0)
        {
            timeDisplay.text = "Regular: " + time.ToString("0.00");
        }

        if (time >= 6f && mode == 2)
        {
            timeDisplay.color = Color.red;
        }
        else if (time <= 3f && mode == 1)
        {
            timeDisplay.color = Color.red;
        }
        else if (time >= 4 && mode == 2)
        {
            timeDisplay.color = Color.yellow;
        }
        else if (time <= 5 && mode == 1)
        {
            timeDisplay.color = Color.yellow;
        }
        else
        {
            timeDisplay.color = Color.white;
        }
    }
}