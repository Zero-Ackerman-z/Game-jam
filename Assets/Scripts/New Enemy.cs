using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    
    private GameObject Personaje;
    private Rigidbody2D enemyRb;
    public float movementSpeed = 2f;
    private Vector2 movementDirection = Vector2.zero;
    public float fieldOfVisionRadius = 3f;
    public float attackRange = 0.5f;
    public int damagePerHit = 10;
    private float attackCooldown = 1.5f;
    private float timeSinceLastAttack;

    
    void Start()
    {
        
        Personaje = GameObject.Find("Personaje");
        enemyRb = GetComponent<Rigidbody2D>();
        timeSinceLastAttack = attackCooldown;
    }

    
    void Update()
    {
        if (Personaje == null) return;

        timeSinceLastAttack += Time.deltaTime;
        
        if (Vector2.Distance(transform.position, Personaje.transform.position) <= fieldOfVisionRadius)
        {
            
            movementDirection = (Personaje.transform.position - transform.position).normalized;
        }
        else
        {
            
            movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        
        enemyRb.velocity = movementDirection * movementSpeed;

        
        if (Vector2.Distance(transform.position, Personaje.transform.position) <= attackRange)
        {
            if (timeSinceLastAttack >= attackCooldown)
            
            AttackPlayer();
            timeSinceLastAttack = 0f;
        }
    }

    
    void AttackPlayer()
    {
        if (Personaje == null) return;
        
        PlayerHealth playerHealth = Personaje.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damagePerHit);
            Debug.Log("El enemigo colisionó e hizo daño");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth !=null)
            {
                playerHealth.TakeDamage(damagePerHit);
                timeSinceLastAttack = 0f;
                Debug.Log("Un enemigo colisionó con el personaje y le hizo daño");
            }
        }
    }
}
