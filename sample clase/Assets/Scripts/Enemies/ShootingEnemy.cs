using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float timeBetweenShoots;
    [SerializeField] Transform pawnPoint;
    [SerializeField] int disparosRafaga;
    [SerializeField] float pausa;

    private void Start()
    {
        StartCoroutine(Rafagas());
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
        Instantiate(prefab, pawnPoint.position, Quaternion.identity);
    }
}
