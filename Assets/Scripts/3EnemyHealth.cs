using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth3 : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth; 

    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage) 
    {
        Debug.Log($"Taking damage: {damage}");
        currentHealth -= damage;
        Debug.Log($"Current health: {currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Character has died!");
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy has died!");
        PlayerHealth playerHealth = GameObject.Find("Personaje").GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(20);
            playerHealth.IncreaseMaxHealth(5);
        }
        Destroy(gameObject);
    }
}
