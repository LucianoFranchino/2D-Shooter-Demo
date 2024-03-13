using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{

    [Header("Die")]
    public int health;
    public GameObject drop;
    private float dropChance = 0.2f;

    public void EnemyTakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (Random.value <= dropChance)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }

    }

}
