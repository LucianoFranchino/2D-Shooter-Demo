using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    public Transform shotPoint;

    protected float timeBtwShots;
    public float startTimeBtwShots;
    [SerializeField] protected Animator anim;

    protected virtual void Update()
    {

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shooting();
                GameObject proyectile = BuletPool.Instance.RequesBulet();
                proyectile.transform.position = shotPoint.position;
                proyectile.transform.rotation = shotPoint.rotation;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }


    private void Shooting()
    {
        anim.SetTrigger("Shoot");
        timeBtwShots = startTimeBtwShots;
    }

}
