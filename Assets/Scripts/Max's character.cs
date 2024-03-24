using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaxHero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 5f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private States State
    {
        get { return (States)anim.GetInteger("animation_id"); }
        set { anim.SetInteger("animation_id", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.jump;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {
        Console.WriteLine(State);
        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }
}

public enum States
{
    idle,
    run,
    jump
}
