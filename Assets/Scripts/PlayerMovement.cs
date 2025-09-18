using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Animator anim;

    public Rigidbody2D rb;


    // Fixed Update is called 50x per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        


        anim.SetFloat("horizontal",horizontal);
        anim.SetFloat("vertical", vertical);




        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;

    }

}
