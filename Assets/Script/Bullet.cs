using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public int bulletDmg = 50;
    public static int bulletForce = 20;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitEff =  Instantiate(hitEffect, transform.position+ -(Vector3.forward), Quaternion.identity);
        
        if (collision.transform.CompareTag("Enemy"))
        {
            Enemy enemy = collision.collider.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.DamageEnemy(bulletDmg);
                Debug.Log("Enemy");
            }

        }
        else
        {
            Player player = collision.collider.GetComponent<Player>();
            if(player != null)
            {
                player.DamagePlayer(bulletDmg);
                Debug.Log("Player");
            }
        }
            
        
        Destroy(gameObject);
        Destroy(hitEff, 0.5f);
        
    }


}
