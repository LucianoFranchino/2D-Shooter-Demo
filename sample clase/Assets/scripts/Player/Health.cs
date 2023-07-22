using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float playerHealth;
    public float currentHealth { get; private set; }

    void Start()
    {
        currentHealth = playerHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0 , playerHealth);

        if (currentHealth > 0)
        {
            //Hurt animation
        }
        else
        {
            //die animation
            Destroy(gameObject);
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //        TakeDamage(1);
    //}
}
