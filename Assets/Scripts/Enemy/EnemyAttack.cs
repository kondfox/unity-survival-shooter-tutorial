using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        anim = GetComponent<Animator> ();
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent<PlayerHealth> ();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (playerInRange && timer >= timeBetweenAttacks)
        {
            Attack ();
        }
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
