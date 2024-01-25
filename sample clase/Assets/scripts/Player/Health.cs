using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float playerHealth;
    public float currentHealth { get; private set; }
    [HideInInspector] public bool isInmune = false;

    void Start()
    {
        currentHealth = playerHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0 , playerHealth);

        if (currentHealth > 0)
        {
            StartCoroutine(Inmunity());
            //Hurt animation
        }
        else
        {
            //die animation
            Destroy(gameObject);
        }
    }

    public IEnumerator Inmunity()
    {
        isInmune = true;
        yield return new WaitForSeconds(0.3f);
        isInmune=false;

    }
 
}
