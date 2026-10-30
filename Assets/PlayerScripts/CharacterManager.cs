using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private SpriteRenderer gunSr;
    [SerializeField] private List<Sprite> gunSprites;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gunSr.sprite = gunSprites[playerSO.currentCharacter];
        if (playerSO.currentCharacter == 0)
        {
            playerSO.bulletsPerChamber = 12;
            playerSO.reloadTime = 2;
            playerSO.shotCooldown = 0.3f;
            playerSO.bulletsShotAtOnce = 1;
            playerSO.coneOfAccuracy = 0;
        }
        if (playerSO.currentCharacter == 1)
        {
            playerSO.bulletsPerChamber = 3;
            playerSO.reloadTime = 1.2f;
            playerSO.shotCooldown = 0.6f;
            playerSO.bulletsShotAtOnce = 3;
            playerSO.coneOfAccuracy = 20;
        }
    }
}
