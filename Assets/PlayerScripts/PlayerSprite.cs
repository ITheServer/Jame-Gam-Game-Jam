using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameStateSO gameStateSO;
    private SpriteRenderer sr;
    [SerializeField] private Material invulnerabilityMaterial;
    [SerializeField] private Material damageMaterial;
    private Material baseMaterial;
    [SerializeField] private Sprite playerDead;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        baseMaterial = sr.material;
        playerData.isHurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStateSO.isPlayerAlive)
        {
            sr.sprite = playerDead;
        }
        if (playerData.invulnerabilityTime > 0)
        {
            if (playerData.isHurt)
            {
                sr.material = damageMaterial;
            }
            else
            {
                sr.material = invulnerabilityMaterial;
            }
        }
        else
        {
            playerData.isHurt = false;
            sr.material = baseMaterial;
        }
    }
}
