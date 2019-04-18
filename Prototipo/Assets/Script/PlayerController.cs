using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //TimeControl
    public float realTime;
    public int timeMode = 0;
    //Fire
    Camera camera;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootSpeed;
    //Movement
    public float Speed;
    public float JumpForce;
    private float MoveInput;
    private Rigidbody2D rb;
    private int Jumps;
    private int JumpsValue;

    //GroundCheck
    private bool isGrounded;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    private bool isWhite;
    public LayerMask WhatIsWhite;

    //Animator
    public Animator animator;
    public bool isDead;

    //Facing direction
    private bool FacingRight = true;

    void Start()
    {
        realTime = 4;
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;

    }

    void FixedUpdate()
    {

        if (!rb)
            return;

        //Ground checks
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsGround);
        isWhite = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsWhite);

        //Movement - left and right
        MoveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveInput * Speed, rb.velocity.y);

        //Facing direction
        if (FacingRight == false && MoveInput > 0)
        {
            Flip();
        }
        else if (FacingRight == true && MoveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        //Time mode
        if (realTime >= 8 || realTime <= 0)
        {
            isWhite = true;
            timeMode = 0;
        }
        if (Time.timeScale != 0)
        {
            if (timeMode == 2)
            {
                //Rapide mode
                Time.timeScale = 1.5f;
                realTime += Time.unscaledDeltaTime;
            }
            else if (timeMode == 1)
            {
                //Slow mode
                Time.timeScale = 0.5f;
                realTime -= Time.unscaledDeltaTime;
            }
            else if (timeMode == 0)
            {
                //Regular mode
                Time.timeScale = 1f;
            }
        }


        //Mouse position
        Vector3 mousePosition = Input.mousePosition;

        Vector3 mpInWorldSpace = camera.ScreenToWorldPoint(mousePosition);

        Vector3 deltaP = mpInWorldSpace - transform.position;

        Vector3 direction = deltaP.normalized;

        Vector3 upVector = Quaternion.Euler(0.0f, 0.0f, 90.0f) * direction;

        Vector3 forwardVector = Vector3.forward;

        if (direction.x < 0.0f)
        {
            upVector = -upVector;
            forwardVector = -forwardVector;
        }

        transform.rotation = Quaternion.LookRotation(forwardVector, upVector);

        Vector3 eulerAngles = transform.localRotation.eulerAngles;



        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        //TimeScale
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (timeMode == 0)
            {
                if (realTime > 4)
                {
                    timeMode = 1;
                }
                else
                {
                    timeMode = 2;
                }
            }
            else if(timeMode == 1)
            {
                timeMode = 2;
            }
            else if(timeMode == 2)
            {
                timeMode = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            timeMode = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            timeMode = 0;
        }

        //Movement - Jumping
        if (timeMode == 1)
        {
            JumpsValue = 0;
        }
        else if (timeMode == 2)
        {
            JumpsValue = 2;
        }
        else
        {
            JumpsValue = 1;
        }
        if (isGrounded == true)
        {
            Jumps = JumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Jumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            Jumps--;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && Jumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
            animator.SetBool("IsJumping", true);
        }

        //Animator
        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
        else if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        }

        if (isWhite == true)
        {
            animator.SetBool("IsDead", true);
            Destroy(rb);
            isDead = false;
        }

        if (isDead == false)
        {
            animator.SetBool("GameOver", true);
        }
    }
    //Facing direction
    void Flip()
    {

        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
    //Shooting
    void Shoot()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rigidBody = newProjectile.GetComponent<Rigidbody2D>();
        rigidBody.velocity = shootSpeed * newProjectile.transform.right;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Projectile"))
        {
            isWhite = true;
        }
    }
}
