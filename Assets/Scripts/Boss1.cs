using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    
    private GameObject player;
    private Rigidbody2D enemyRb;

    
    public float movementSpeed = 2f;
    private Vector2 movementDirection = Vector2.zero;

    
    public float fieldOfVisionRadius = 8f;

    
    public float attackRange = 0.5f;

    
    public int damagePerHit = 30;

    
    public float chargeTime = 1.5f;
    public float dashSpeed = 6f;
    private bool isChargingAttack = false;
    private bool isDashing = false;
    
    void Start()
    {
        player = GameObject.Find("Personaje");
        enemyRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
        if (Vector2.Distance(transform.position, player.transform.position) <= fieldOfVisionRadius)
        {
            
            if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
            {
                
                isChargingAttack = true;
                movementDirection = Vector2.zero; 
            }
            else
            {
                
                movementDirection = (player.transform.position - transform.position).normalized;
            }
        }
        else
        {
            
            movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        
        if (!isChargingAttack)
        {
            enemyRb.velocity = movementDirection * movementSpeed;
        }

        
        if (isChargingAttack)
        {
            StartCoroutine(PerformDashAttack());
        }
    }

    
    private IEnumerator PerformDashAttack()
    {
        
        yield return new WaitForSeconds(chargeTime);

        
        isChargingAttack = false; 
        enemyRb.velocity = movementDirection * dashSpeed;

        
        GetComponent<Collider2D>().enabled = false;

        
        yield return new WaitForSeconds(1f); 

        
        enemyRb.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = true;
        isDashing = false;
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damagePerHit);
        }
    }
}
