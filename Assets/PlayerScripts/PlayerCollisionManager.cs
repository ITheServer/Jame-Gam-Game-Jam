using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    [SerializeField] private GameObject pickupSFX;
    [SerializeField] private GameObject hurtSFX;

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
                playerData.playerSO.health--;
                if (playerData.playerSO.health == 0)
                {
                    playerData.gameStateSO.isPlayerAlive = false;
                }
                Instantiate(hurtSFX);
                playerData.playerSO.invulnerabilityTime = 0.3f;
                playerData.playerSO.isHurt = true;
            }
        }
        if (collision.gameObject.CompareTag("Pickup"))//heal
        {
            if (playerData.playerSO.health < playerData.playerSO.maxHealth)
            {
                playerData.playerSO.health++;
                Instantiate(pickupSFX);
                Destroy(collision.gameObject);
            }
        }
    }
}
