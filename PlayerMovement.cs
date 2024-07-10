using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]


public class PlayerMovement : MonoBehaviour
{
    //necessary for animations and physics
    private Rigidbody2D rb2d;
    private Animator myAnimator;

    public float speed = 2.0f;
    public float horizMovement;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<myAnimator>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizMovement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        rb2d.velocity = 
    }
}
