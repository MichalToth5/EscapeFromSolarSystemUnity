using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : MonoBehaviour
{
    public float rayLength = 2f;
    public LayerMask layerMask;
    public float attackDelay = 4f;
    public Animator animator;
    private HealthBar playerHealth;
    public int attackDamage = 1;
    public int health = 3;

    public float patrolSpeed = 2f;
    public Transform leftEdge;
    public Transform rightEdge;
    private bool facingLeft = true;
    private bool isAttacking = false;
    private bool isDead = false;


    private float lastAttackTime = 0f;
    RaycastHit2D hit;
    private Transform playerTransform;
    public float raycastOffset = 0.5f;  // Offset from the enemy's center

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isAttacking || isDead)
        {
            MeleeAttack();
            isAttacking = false;
        }
        else
        {
            Patroling();
            if (facingLeft)
            {
                Vector2 direction = playerTransform.position - transform.position;

                if (Vector2.Dot(direction, transform.right) > 0f)
                {
                    Vector2 raycastStart = (Vector2)transform.position + direction.normalized * raycastOffset;

                    RaycastHit2D hit = Physics2D.Raycast(raycastStart, direction, rayLength, layerMask);

                    if (hit && hit.collider.CompareTag("Player"))
                    {
                        Flip();
                    }
                }
            }
            else
            {
                Vector2 direction = playerTransform.position - transform.position;

                if (Vector2.Dot(direction, transform.right) < 0f)
                {
                    Vector2 raycastStart = (Vector2)transform.position + direction.normalized * raycastOffset;

                    RaycastHit2D hit = Physics2D.Raycast(raycastStart, direction, rayLength, layerMask);

                    if (hit && hit.collider.CompareTag("Player"))
                    {
                        Flip();
                    }
                }
            }
        }
     
    }

    private void MeleeAttack()
    {
        if (facingLeft)
        {
            Vector2 rayDirection = transform.right + (Vector3)(-transform.right) * 2;
            hit = Physics2D.Raycast(transform.position, rayDirection, rayLength, layerMask);
            
            if (hit.collider != null && hit.collider.gameObject.tag == "Player" && Time.time > lastAttackTime + attackDelay)
            {
                animator.SetTrigger("meleeAttack");
                lastAttackTime = Time.time;
            }
        }
        else
        {
            
            Vector2 rayDirection = transform.TransformDirection(Vector2.right);
            hit = Physics2D.Raycast(transform.position, rayDirection, rayLength, layerMask);
            
            if (hit.collider != null && hit.collider.gameObject.tag == "Player" && Time.time > lastAttackTime + attackDelay)
            {
                animator.SetTrigger("meleeAttack");
                lastAttackTime = Time.time;
            }
        }
    }
    private void DamagePlayer()
    {
        playerHealth = hit.collider.GetComponent<HealthBar>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    private void Patroling()
    {
        //Collider2D hit = Physics2D.OverlapCircle(transform.position, rayLength, layerMask);
        Vector2 raycastDirection = facingLeft ? Vector2.left : Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, rayLength, layerMask);
        if (hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            animator.SetBool("moving", false);
            isAttacking = true;
        }
        else
        {
            animator.SetBool("moving", true);
            isAttacking = false;
            float horizontal = facingLeft ? -patrolSpeed : patrolSpeed;
            transform.position = new Vector2(transform.position.x + horizontal * Time.deltaTime, transform.position.y);

            if (facingLeft && transform.position.x < leftEdge.position.x)
            {
                Flip();
            }
            else if (!facingLeft && transform.position.x > rightEdge.position.x)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    public void Hurt(int damage)
    {
        if (!isDead)
        {
            health -= damage;
            animator.SetTrigger("hurt");
            if (health <= 0)
            {
                Die();
            }
        }
        
    }
    private void Die()
    {
        isDead = true;
        animator.SetBool("moving", false);
        animator.SetTrigger("die");
        StartCoroutine(DestroyEnemy());
    }
    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}