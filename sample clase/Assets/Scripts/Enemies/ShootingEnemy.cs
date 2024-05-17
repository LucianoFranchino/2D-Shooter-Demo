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
    private bool isShooting = false;

    [Header("Range")]
    [SerializeField] float lineDistance;
    public LayerMask playerCapa;
    bool playerRange;

    [Header("Bulet")]
    [SerializeField] Transform pawnPoint;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Range();
        LookAtPlayer();
    }

    void Range()
    {
        playerRange = Physics2D.Raycast(pawnPoint.position, transform.right, lineDistance,playerCapa);
        if (playerRange && !isShooting)
        {
            StartCoroutine(Rafagas());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pawnPoint.position, pawnPoint.position + transform.right * lineDistance);
    }

    void LookAtPlayer()
    {
        float direction = target.position.x - transform.position.x;

        if (direction < 0)
        {
            // Rota hacia la izquierda
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (direction > 0)
        {
            // Rota hacia la derecha
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    IEnumerator Rafagas()
    {
        isShooting = true;

        while (true)
        {
            for (int i = 0; i < disparosRafaga; i++)
            {
                Shoot();
                yield return new WaitForSeconds(timeBetweenShoots);
            }
            yield return new WaitForSeconds(pausa);

            RaycastHit2D playerRange = Physics2D.Raycast(pawnPoint.position, transform.right, lineDistance, playerCapa);
            if (!playerRange)
            {
                break;
            }
        }
        isShooting = false;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(prefab, pawnPoint.position, pawnPoint.rotation);
    }
}
