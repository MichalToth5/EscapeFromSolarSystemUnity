using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth = 10;
    public Transform startPoint;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Slider healthSlider;
    private Animator animator;
    private Rigidbody2D rb;
    private bool playerIsHurt = false;
    private bool spawn1 = false;
    private bool spawn2 = false;
    public AudioSource takeDamageSound;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealthDown"))
        {
            takeDamageSound.Play();
            currentHealth--;
            healthSlider.value = currentHealth;
            playerIsHurt = true;
            if (currentHealth < 1)
            {
                Die();
            }
            else if(currentHealth > 0 && spawn1 == true || 
                    currentHealth > 0 && spawn2 == true)
            {
                SpawnOnPoint();
            }
            else
            {
                transform.position = startPoint.position;
            }
        }

        if (collision.gameObject.CompareTag("HealthUp"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Spawn1"))
        {
            spawn1 = true;
        }
        if (collision.gameObject.CompareTag("Spawn2"))
        {
            spawn1 = false;
            spawn2 = true;
        }
    }
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("hurt");
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        StartCoroutine(RestartLevel());
    }

    private void SpawnOnPoint()
    {
        if (playerIsHurt == true && spawn1 == true)
        {
            transform.position = spawnPoint1.position;
        }
        if (playerIsHurt == true && spawn2 == true)
        {
            transform.position = spawnPoint2.position;
        }
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
