using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public float attackRange = 4f;
    public int attackDamage = 1;
    public Animator animator;
    public LayerMask enemyLayerMask;
    private PlayerMovement playerMovement;
    public GameObject projectilePrefab;
    public int maxBullets = 10;
    public int currentBullets = 0;
    public Slider magazineSlider;
    public float projectileSpeed = 10.0f;
    public float offsetX = 2f;
    public float offsetY = 0.1f;
    public AudioSource shootingSound;
    public Transform attackImage;
    public Transform rangedAttackImage;
    private bool canRangeAttack;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        magazineSlider.value = currentBullets;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
        }
        if (Input.GetMouseButtonDown(1) && currentBullets > 0)
        {
            RangeAttack();
        }
       
        if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(rangedAttackImage.GetComponent<RectTransform>(), Input.mousePosition) && currentBullets > 0)
        {
            canRangeAttack = true;
        }

        if (canRangeAttack && Input.GetMouseButtonUp(0))
        {

            RangeAttack();
            canRangeAttack = false;
        }
    }
    

    private void MeleeAttack()
    {
        animator.SetTrigger("attack");
        if (playerMovement.isFacingRight)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, attackRange, enemyLayerMask);
            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<MeeleEnemy>().Hurt(attackDamage);
                }
                if (hit.collider.CompareTag("RangedEnemy"))
                {
                    hit.collider.GetComponent<RangedEnemy>().Hurt(attackDamage);
                }
                 
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, attackRange, enemyLayerMask);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<MeeleEnemy>().Hurt(attackDamage);
                }
                if (hit.collider.CompareTag("RangedEnemy"))
                {
                    hit.collider.GetComponent<RangedEnemy>().Hurt(attackDamage);
                }
            }
        }
    }

    private void RangeAttack()
    {
        shootingSound.Play();
        currentBullets--;
        magazineSlider.value = currentBullets;
        animator.SetTrigger("rangedAttack");
        if (playerMovement.isFacingRight)
        {
            Vector3 spawnPosition = transform.position + (transform.right * offsetX) + (transform.up * offsetY);
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);
            Rigidbody2D rigidbody2D = projectile.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
        }
        else
        {
            Vector3 spawnPosition = transform.position + (-transform.right * offsetX) + (transform.up * offsetY);
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);
            Rigidbody2D rigidbody2D = projectile.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = -transform.right * projectileSpeed;
        }
    }
   
}
