using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    //[SerializeField] private SpriteRenderer gunSr;
    //[SerializeField] private SpriteRenderer gunSprites;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            playerSO.bulletsPerChamber = 12;
            playerSO.reloadTime = 1;
            playerSO.shotCooldown = 2f;
            playerSO.bulletsShotAtOnce = 3;
            playerSO.coneOfAccuracy = 45;
        }
    }
}
