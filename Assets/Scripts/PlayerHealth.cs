using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private HealthBar healthBar;
    public int maxHealth = 100;

    
    public int currentHealth;

    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    public void TakeDamage(int damage)
    {
        Debug.Log($"Taking damage: {damage}");
        currentHealth -= damage;
        Debug.Log($"Current health: {currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Character has died!");
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject);
        uIManager.GameOverPanel();

    }
}
