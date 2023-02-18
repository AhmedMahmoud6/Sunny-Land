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


    Transform mytransform;
    SpriteRenderer myRenderer;
    Rigidbody2D rb;
    Animator anim;

    public int playerHealth = 3;

    bool isJump;

    void Start()
    {
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
        }

        if (Mathf.Abs(rb.velocity.y) < 0.06f)
        {
            isJump = false;
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
            playerHealth--;
        }
    }


}
