using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 input;
    public float speed = 5;
    public Animator anim;

    private Vector2 lastMoveDiraction;
    private bool facingLeft = true;

    public Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessInputs();
        Animate();
        if (input.x < 0 && !facingLeft || input.x > 0 && !facingLeft)
        {
            Flip();
        }
    }


    // Fixed Update is called 50x per frame
    void FixedUpdate()
    {

        rb.linearVelocity = input * speed;

    }


    void ProcessInputs()
    {
        //Store last move direction when we stop moving
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0))
        {
            lastMoveDiraction = input;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

    }
    void Animate()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDiraction.x);
        anim.SetFloat("LastMoveY", lastMoveDiraction.y);

    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }

}
