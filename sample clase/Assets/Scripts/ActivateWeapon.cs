using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWeapon : MonoBehaviour
{

    public PickUpWeapon pickUp;
    public GameObject weapon;
    [SerializeField] Shoot shoot;
    public int num;

    void Start()
    {
        pickUp = GameObject.FindGameObjectWithTag("Player").GetComponent<PickUpWeapon>();
        shoot = weapon.GetComponent<Shoot>();
        shoot.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pickUp.ActivateWeapon(num);
            shoot.enabled = true;
            Destroy(gameObject);
        }
    }
}
