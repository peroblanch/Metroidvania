using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]


public class PlayerMovement : MonoBehaviour
{
    //necessary for animations and physics
    private Rigidbody2D rb2d;
    private Animator myAnimator;

    private bool facingRight = true;

    public float speed = 4.0f;
    public float horizMovement; // 1 || -1 || 0

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizMovement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() {
        rb2d.velocity = new Vector2(horizMovement*speed, rb2d.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }

    private void Flip(float movement) {
        if (movement < 0 && facingRight || movement > 0 && !facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }


}
