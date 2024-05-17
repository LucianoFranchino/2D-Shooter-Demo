using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulet : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] private float speed;

    void Start()
    {
        Invoke("BuletLife", 3f);
    }
    private void Update()
    {
        DirectionB();
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

    void DirectionB()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void BuletLife()
    {
        Destroy(gameObject);
    }
}
