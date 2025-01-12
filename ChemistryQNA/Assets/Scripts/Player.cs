using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed = 2.0f;
    public float jump = 5.0f;
    private float Move;
    private float Climb;
    private bool isLadder;
    private bool isClimbing;

    private Rigidbody2D rb;

    //public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        Climb = Input.GetAxis("Vertical");

        Debug.Log(Move);
        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        //animator.SetBool("IsWalking", Mathf.Abs(Move) > 0.1f);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        if (Move > 0.1f) // Moving to the right
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Move < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (isLadder && Mathf.Abs(Climb) > 0.0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, Climb * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
