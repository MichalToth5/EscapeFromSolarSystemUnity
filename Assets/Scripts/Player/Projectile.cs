using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int projectileDamage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag == "Enemy")
        {
            collision.collider.GetComponent<MeeleEnemy>().Hurt(projectileDamage);
        }
        if (collision.gameObject.tag == "RangedEnemy")
        {
            collision.collider.GetComponent<RangedEnemy>().Hurt(projectileDamage);
        }
        Destroy(gameObject);
    }
}
