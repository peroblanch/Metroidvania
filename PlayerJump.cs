using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    
    [Header("Jump Details")]
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool jumpDone;

    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatGround;
    [SerializeField] private float radOCircle;
    public bool grounded;

    [Header("Components")]

    private Rigidbody2D rb;

    

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;

    }

    private void Update(){

        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatGround);

        if (grounded) {
            jumpTimeCounter = jumpTime;
            jumpDone = false;
        }

        if(Input.GetButtonDown("Jump") && grounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(Input.GetButton("Jump") && !jumpDone){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonUp("Jump") || jumpTimeCounter <= 0) {
            jumpTimeCounter = 0;
            jumpDone = true;
        }


    }

    private void OnDrawGizmos(){
        Gizmos.DrawSphere(groundCheck.position, radOCircle);
    }
}
