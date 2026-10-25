using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameStateSO gameStateSO;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    [SerializeField] private GameObject pickupSFX;
    [SerializeField] private GameObject hurtSFX;

    void Awake()
    {
        gameStateSO.isPlayerAlive = true;
        playerData.maxHealth = 6;
        playerData.health = playerData.maxHealth;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerData.invulnerabilityTime -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hurt"))//enemy or bullet
        {
            if (playerData.invulnerabilityTime < 0)
            {
                playerData.health--;
                if (playerData.health == 0)
                {
                    gameStateSO.isPlayerAlive = false;
                }
                Instantiate(hurtSFX);
                playerData.invulnerabilityTime = 0.3f;
                playerData.isHurt = true;
            }
        }
        if (collision.gameObject.CompareTag("Pickup"))//heal
        {
            if (playerData.health < playerData.maxHealth)
            {
                playerData.health++;
                Instantiate(pickupSFX);
                Destroy(collision.gameObject);
            }
        }
    }
}
