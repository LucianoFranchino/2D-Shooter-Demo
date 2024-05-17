using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField] int disparosRafaga;
    [SerializeField] float pausa;
    [SerializeField] private float timeBetweenShoots;
    private Transform target;

    [Header("Bulet")]
    [SerializeField] Transform pawnPoint;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        StartCoroutine(Rafagas());
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        float direction = target.position.x - transform.position.x;

        // Rota el sprite del enemigo
        if (direction > 0)
        {
            transform.localScale = new Vector2(-2, 2); // Rota hacia la derecha
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector2(2, 2); // Rota hacia la izquierda
        }
    }

    IEnumerator Rafagas()
    {
        while (true)
        {
            for (int i = 0; i < disparosRafaga; i++)
            {
                Shoot();
                yield return new WaitForSeconds(timeBetweenShoots);
            }
            yield return new WaitForSeconds(pausa);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(prefab, pawnPoint.position, pawnPoint.rotation);
    }
}
