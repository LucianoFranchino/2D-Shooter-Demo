using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalBar;
    [SerializeField] private Image CurrentHealth;
    void Start()
    {
        totalBar.fillAmount = playerHealth.currentHealth;
    }

    void Update()
    {
        CurrentHealth.fillAmount = playerHealth.currentHealth / 3;
    }
}
