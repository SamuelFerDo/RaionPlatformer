using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float defaultSpeed;
    [SerializeField] protected Vector2 direction;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float jumpForce;
    [SerializeField] protected float gravity, fallMultiplier;
    [SerializeField] protected bool grounded;

    protected float jumpTimeCounter;
    protected bool isJumping;
    [SerializeField] public float jumpTime;

    public Transform feetPos;
    [SerializeField] public float checkRadius;
    public LayerMask whatIsGround;

    protected Animator anim;

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void Movement(float _direction)
    {
        if (_direction != 0)
        {
            anim.SetBool("Walk", true);
        }   
        direction.x = _direction;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        PlayerFlip();
    }
    public void MovementVelocity(float _direction)
    {
        if (_direction != 0)
        {
            anim.SetBool("Walk", true);
        }
        direction.x = _direction;
        direction.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        PlayerFlip();
    }   
    public void PlayerFlip()
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    public void ModifyPhysic()
    {
        if (grounded)
        {
            rb.gravityScale = 0;
        }else
            if(rb.velocity.y < 0)
        {
            rb.gravityScale = gravity * fallMultiplier;
        }else if (rb.velocity.y > 0)
        {
            rb.gravityScale = gravity * (fallMultiplier / 2);
        }
    }
    public void Run(float _direction)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
            anim.SetBool("Run", true);
        }
        
    }
    public void RunJump()
    {
        grounded = false;
        anim.SetBool("RunJump", true);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public void JumpHold()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            anim.SetBool("Jump", true);
            jumpTimeCounter = jumpTime;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetBool("RunJump", false);
            anim.SetBool("Jump", false);
        }
    }
}
