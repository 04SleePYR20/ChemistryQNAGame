using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed = 5.0f;
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

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        //animator.SetBool("IsWalking", Mathf.Abs(Move) > 0.1f);

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
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        else if (collision.CompareTag("Death"))
        {
            ResetScene();
        }
        else if (collision.CompareTag("Portal"))
        {
            NextScene();
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

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load. This is the last scene.");
        }
    }

}
