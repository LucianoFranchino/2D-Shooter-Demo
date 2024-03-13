using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulet : MonoBehaviour
{
    private Health playerHealth;

    void Start()
    {
        Invoke("BuletLife", 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth= collision.gameObject.GetComponent<Health>();
            playerHealth.TakeDamage(1);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    void BuletLife()
    {
        Destroy(gameObject);
    }
}
