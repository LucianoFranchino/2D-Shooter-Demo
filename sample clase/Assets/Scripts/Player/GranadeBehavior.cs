using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GranadeBehavior : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float lifeTime;
    [SerializeField] float radio;
    [SerializeField] float explocionForce;


    private void Start()
    {
        Invoke("Explosion", 1);
    }

    public void Explosion()
    {
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(transform.position, radio);
        foreach (Collider2D coll in enemigos)
        {
            if (coll.CompareTag("Enemy"))
            {
                EnemiesHealth vidaEnemigo = coll.GetComponent<EnemiesHealth>();
                if(vidaEnemigo != null)
                {
                    Debug.Log("Hit");
                    vidaEnemigo.EnemyTakeDamage(damage);
                }
            }
        }

        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radio);   
        foreach (Collider2D coll in objects)
        {
            Rigidbody2D rb2D = coll.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direccion = coll.transform.position - transform.position;
                float distancia = direccion.magnitude;
                float fuerzaFinal = explocionForce / distancia;
                rb2D.AddForce(direccion.normalized * fuerzaFinal, ForceMode2D.Impulse);
            }
  
        }
    
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
