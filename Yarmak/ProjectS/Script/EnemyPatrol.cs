using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject leftBorder;
    public GameObject rightBorder;
    public Rigidbody2D rigidbody;
    public GroundDetection groundDetection;
    public bool isRightDirection;
    public Vector3 direction;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public float speed;

    private void Start()
    {
        groundDetection = GetComponent<GroundDetection>();
    }

    private void Update()
    {

        direction = Vector3.zero;
        if (isRightDirection && groundDetection.isGrounded)
        {
            direction = Vector3.right;
            rigidbody.velocity = Vector3.right * speed;
            if (transform.position.x > rightBorder.transform.position.x)
                isRightDirection = !isRightDirection;
        }
        else if (groundDetection.isGrounded) 
        {
            direction = Vector3.left;
            rigidbody.velocity = Vector3.left * speed;
            if (transform.position.x < leftBorder.transform.position.x)
                    isRightDirection = !isRightDirection;
        }
        if (direction.x < 0)
            spriteRenderer.flipX = false;
        if (direction.x > 0)
            spriteRenderer.flipX = true;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            animator.SetTrigger("EnemyControl");
            Debug.Log("enemyControls");

        }
        
        

    }

}
