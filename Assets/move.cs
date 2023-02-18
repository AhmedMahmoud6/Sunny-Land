using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class move : MonoBehaviour
{
    [SerializeField]
    float speed = 0.05f;

    [SerializeField]
    float jump = 10f;

    public int score;

    Transform mytransform;
    SpriteRenderer myRenderer;
    Rigidbody2D rb;
    Animator anim;

    public int playerHealth = 12;

    bool isJump;

    void Start()
    {
        score = 0;
        isJump = false;
        mytransform = GetComponent<Transform>();
        myRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(-1 * speed,0,0);
            myRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(speed, 0, 0);
            myRenderer.flipX = false;

        }
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rb.velocity = new Vector2(0,jump);
            isJump = true;
            anim.SetBool("Isjump",true);
        }

        if (Mathf.Abs(rb.velocity.y) < 0.06f)
        {
            isJump = false;
            anim.SetBool("Isjump", false);

        }

        anim.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (isJump && rb.velocity.y < 0)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                playerHealth--;
            }
        }
        else if(collision.CompareTag("Gem"))
        {
            score += 100;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Cherry"))
        {
            score += 50;
            Destroy(collision.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isJump && rb.velocity.y < 0)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                playerHealth--;
            }
        }
    }


}
