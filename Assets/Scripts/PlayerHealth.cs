using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 100;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private UIManager uIManager;

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

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Healed: {amount}. Current health: {currentHealth}");
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Increased max health by: {amount}. New max health: {maxHealth}");
    }

    public void Die()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject);
        uIManager.GameOverPanel();

    }
}
