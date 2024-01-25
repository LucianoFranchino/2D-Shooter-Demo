using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Health playerHealth;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();

        LaunchProyectile();
    }

    private void LaunchProyectile()
    {
        Vector2 direction = new Vector2(-1,0);
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
