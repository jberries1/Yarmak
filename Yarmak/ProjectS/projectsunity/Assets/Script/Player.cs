using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 2.5f;
    public float force;
    public new Rigidbody2D rigidbody;
    public float minimalHeight;
    public bool isCheetMoode;
    public GroundDetection groundDetection;
    public Vector3 direction;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool isJumping;
   

    void FixedUpdate()
    {
        animator.SetBool("IsGrounded", groundDetection.isGrounded);
        if (!isJumping && !groundDetection.isGrounded)
            animator.SetTrigger("StartFall");
        isJumping = isJumping && !groundDetection.isGrounded;
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            direction = Vector3.left;

        if (Input.GetKey(KeyCode.D))
            direction = Vector3.right;
        direction *= speed;
        direction.y = rigidbody.velocity.y;
        rigidbody.velocity = direction;

        if (Input.GetKeyDown(KeyCode.Space) && groundDetection.isGrounded)
        {
            rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            animator.SetTrigger("StartJump");
            isJumping = true;
        }
        if (direction.x > 0)
            spriteRenderer.flipX = false;
        if (direction.x < 0)
            spriteRenderer.flipX = true;

        animator.SetFloat("Speed", Mathf.Abs(direction.x));
        CheckFall();
        



    }
    void CheckFall()
    {
        //cheatMode
        if (transform.position.y < minimalHeight && isCheetMoode)
        {
            rigidbody.velocity = new Vector2(0, 0);
            transform.position = new Vector3(0, 0, 0);

        }
        else if (transform.position.y < minimalHeight && !isCheetMoode)
            Destroy(gameObject);

    }
}
