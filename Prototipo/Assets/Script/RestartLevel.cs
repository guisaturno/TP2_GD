using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartLevel : MonoBehaviour {

    private Scene Scene;

    private bool isWhite;
    public LayerMask WhatIsWhite;
    public Transform GroundCheck;
    public float CheckRadius;
    public GameObject LevelStart;

    private GameMaster gm;

    private void Awake()
    {
        gameObject.transform.position = LevelStart.transform.position;
    }

    void Start ()
    {
        Scene = SceneManager.GetActiveScene();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.LastCheckPointPos;
    }
	
	void FixedUpdate ()
    {
        isWhite = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsWhite);
    }

    void Update()
    {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(Scene.name);
            }
    }
  
}
