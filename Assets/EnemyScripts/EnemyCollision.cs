using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyCollision : MonoBehaviour
{
    private EnemyData enemyData;
    [SerializeField] private GameObject hitSFX;
    [SerializeField] private GameObject pickupSFX;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject heal;
    [SerializeField] private GameObject money;
    [SerializeField] private bool deadNextFrame;

    private void Start()
    {
        deadNextFrame = false;
        enemyData = GetComponent<EnemyData>();
        if (enemyData != null)
        {
            Debug.Log("Enemy data class successfully found.");
        }
    }

    private void Update()
    {
        if (!enemyData.gameStateSO.isPlayerAlive || enemyData.gameStateSO.roundCompleted)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //prevents multiple onCollisionEnter triggers in one frame when enemy is dead
        //this happens when a enemy hits multiple bullets in one frame
        if (!deadNextFrame)
        {
            if (collision.gameObject.CompareTag("Player Bullet"))
            {
                //Projectile projectile = collision.gameObject.GetComponent<Projectile>();
                enemyData.damageTimer = 0.3f;
                enemyData.health--;
                enemyData.gameStateSO.shotsLanded++;
                enemyData.gameStateSO.score += 1;
                Instantiate(hitSFX);
                if (enemyData.health <= 0)
                {
                    deadNextFrame = true;
                    Destroy(gameObject);
                    Instantiate(deathEffect, transform.position, Quaternion.identity);
                    if (Random.Range(0, 20) == 0)//5% chance for health pickup
                    {
                        Instantiate(pickupSFX);
                        Instantiate(heal, transform.position, Quaternion.identity);
                    }
                    Instantiate(money, transform.position, Quaternion.identity);
                    enemyData.gameStateSO.score += 10;
                    enemyData.gameStateSO.slimesKilled++;
                }
            }
        }
    }
}
