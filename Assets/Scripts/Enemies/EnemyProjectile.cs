using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int projectileDamage = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.GetComponent<HealthBar>().TakeDamage(projectileDamage);
        }
        Destroy(gameObject);
    }
}
