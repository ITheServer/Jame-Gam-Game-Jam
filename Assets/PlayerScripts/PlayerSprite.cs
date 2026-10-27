using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Material invulnerabilityMaterial;
    [SerializeField] private Material damageMaterial;
    private Material baseMaterial;
    [SerializeField] private Sprite playerDead;


    void Awake()
    {
        baseMaterial = playerData.sr.material;
        playerData.isHurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerData.gameStateSO.isPlayerAlive)
        {
            playerData.sr.sprite = playerDead;
        }
        if (playerData.invulnerabilityTime > 0)
        {
            if (playerData.isHurt)
            {
                playerData.sr.material = damageMaterial;
            }
            else
            {
                playerData.sr.material = invulnerabilityMaterial;
            }
        }
        else
        {
            playerData.isHurt = false;
            playerData.sr.material = baseMaterial;
        }
    }
}
