using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class NewMovement : MonoBehaviour
{
    
    public float Speed;
    public float attackRange = 3f;
    public int damagePerHit = 15;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private float Vertical;
    private LayerMask enemyLayer;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        enemyLayer = LayerMask.GetMask("Enemigo");

        Debug.Log("LayerMask configurado para enemigos" + enemyLayer.value);
    }

    
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Horizontal *= Speed;


        if (Horizontal < 0.0f) transform.localScale = new UnityEngine.Vector3(-0.1096917f, 0.1096917f, 0.1096917f);
        else if (Horizontal > 0.0f) transform.localScale = new UnityEngine.Vector3(0.1096917f, 0.1096917f, 0.1096917f);

        Vertical = Input.GetAxisRaw("Vertical");

        Vertical *= Speed;


        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Se presionó la tecla J");
            PerformMeleeAttack();
        }
    }

    private void FixedUpdate()
    {

        Rigidbody2D.velocity = new UnityEngine.Vector2(Horizontal, Rigidbody2D.velocity.y);
        Rigidbody2D.velocity = new UnityEngine.Vector2(Rigidbody2D.velocity.x, Vertical);
    }

    void PerformMeleeAttack()
    {
        Debug.DrawLine(transform.position, transform.position + (UnityEngine.Vector3)(UnityEngine.Vector2.right * attackRange), Color.red, 1.0f);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        Debug.Log("Número de enemigos detectados: " + hitEnemies.Length);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            EnemyHealth enemyHealth = enemyCollider.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Debug.Log("Atacando enemigo");
                enemyHealth.TakeDamage(damagePerHit);
            }
            else
            {
                Debug.Log("No se encontró el componente EnemyHealth en el enemigo");
            }


            EnemyHealth3 enemyHealth3 = enemyCollider.gameObject.GetComponent<EnemyHealth3>();
            if (enemyHealth3 != null)
            {
                Debug.Log("Atacando enemigo");
                enemyHealth3.TakeDamage(damagePerHit);
            }
            else
            {
                Debug.Log("No se encontró el componente EnemyHealth en el enemigo");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Personaje colisionó con un enemigo");
        }
    }
}
