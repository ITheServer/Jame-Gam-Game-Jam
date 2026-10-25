using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    private EnemyData enemyData;
    [SerializeField] private GameStateSO gameStateSO;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float directionChangeTimer;
    [SerializeField] private float directionChangeRateMin;
    [SerializeField] private float directionChangeRateMax;
    [SerializeField] private bool followPlayer;
    [SerializeField] private bool reverseDirection;//used for making enemies that run from the player

    [SerializeField] private float recoilTimer;
    [SerializeField] private float recoilLength;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject heal;
    [SerializeField] private GameObject hitSFX;
    [SerializeField] private GameObject pickupSFX;


    void Start()
    {
        enemyData = GetComponent<EnemyData>();
        if (enemyData != null)
        {
            Debug.Log("Enemy data class successfully found.");
        }
        directionChangeTimer = Random.Range(directionChangeRateMin, directionChangeRateMax);
        GetMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        directionChangeTimer -= Time.deltaTime;
        if (directionChangeTimer < 0)
        {
            directionChangeTimer = Random.Range(directionChangeRateMin, directionChangeRateMax);
            GetMoveDirection();
        }
        if (enemyData.applyRecoil)
        {
            enemyData.applyRecoil = false;
            recoilTimer = recoilLength;
        }
        if (!gameStateSO.isPlayerAlive)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        if (recoilTimer > 0)
        {
            recoilTimer -= Time.deltaTime;
            enemyData.rb.AddForce(enemyData.recoilPower * (recoilTimer / recoilLength) * Time.deltaTime * enemyData.recoilDirection, ForceMode2D.Impulse);
        }
        enemyData.rb.AddForce(moveSpeed * Time.deltaTime * moveDirection, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection = -moveDirection;//simple fix to send enemy back where it came from when it hits a wall
        if (collision.gameObject.CompareTag("Player Bullet"))
        {
            enemyData.damageTimer = 0.3f;
            enemyData.health--;
            gameStateSO.shotsLanded++;
            gameStateSO.score += 1;
            Instantiate(hitSFX);
            if (enemyData.health <= 0)
            {
                Destroy(gameObject);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                if (Random.Range(0,20) == 0)//5% chance for health pickup
                {
                    Instantiate(pickupSFX);
                    Instantiate(heal, transform.position, Quaternion.identity);
                }
                gameStateSO.score += 10;
                gameStateSO.slimesKilled++;
            }
        }
    }
    private void GetMoveDirection()
    {
        if (followPlayer)
        {
            moveDirection = (enemyData.player.transform.position - transform.position).normalized;
        }
        else
        {
            moveDirection = Random.insideUnitCircle.normalized;
        }
        if (reverseDirection)
        {
            moveDirection = -moveDirection;
        }
    }
}
