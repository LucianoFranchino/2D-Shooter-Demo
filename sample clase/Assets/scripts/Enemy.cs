using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Atack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D bxCollider;
    [SerializeField] private LayerMask playerMask;
    private float cooldownTimer = Mathf.Infinity;
    private Health playerHealth; 

    [Header("Mov")]
    public float speed;
    public float stopDistance;
    private Transform target;
    public int health;
    //public GameObject deathEffect;
    //public GameObject explosion;
    [Header("Animation")]
    private Animator anim;

    [Header("Die")]
    public GameObject drop;
    private float dropChance = 0.2f;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position)> stopDistance)
        {
            anim.SetTrigger("Run");
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

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

        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }
        
    }

    private bool PlayerInSight()
    {
        //creamos una hitbox que cuando el jugador ingresa dentro de esta el enemigo hace el ataque
        RaycastHit2D hit = Physics2D.BoxCast(bxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance, 
            new Vector3(bxCollider.bounds.size.x * attackRange, bxCollider.bounds.size.y, bxCollider.bounds.size.z),0,Vector2.left,0, playerMask);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    //aca solo pintamos el collider para testear
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            new Vector3(bxCollider.bounds.size.x * attackRange, bxCollider.bounds.size.y, bxCollider.bounds.size.z));
    }

    public void EnemyTakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (Random.value <= dropChance)
             {
                Instantiate(drop, transform.position, Quaternion.identity);
             }

          Destroy(gameObject);
        }
        
    }

    public void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
