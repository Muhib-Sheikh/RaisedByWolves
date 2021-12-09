using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    public float moveSpeed = 2.75f;

    public Rigidbody2D rb ;

    Vector2 movement;

    public Animator animator;

    public static int playerScore = 0;

    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed" , movement.sqrMagnitude);
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    

    
}
