using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed = 2.0f;
    private float Move;

    private Rigidbody2D rb;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        Debug.Log(Move);
        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        animator.SetBool("IsWalking", Mathf.Abs(Move) > 0.1f);

        if (Move > 0.1f) // Moving to the right
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Move < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
