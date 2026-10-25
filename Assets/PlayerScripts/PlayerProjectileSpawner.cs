using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerProjectileSpawner : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float maxCoolDown;
    [SerializeField] private float currentCoolDown;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunPos;
    [SerializeField] private GameObject shotSFX;
    [SerializeField] private GameObject reloadSFX;
    [SerializeField] private GameStateSO gameStateSO;

    private bool reloading;
    // Start is called before the first frame update
    void Awake()
    {
        playerData.bullets = playerData.bulletsPerChamber;
        reloading = false;
        currentCoolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if (reloading)
        {
            if (currentCoolDown < 0)//done reloading
            {
                playerData.bullets = playerData.bulletsPerChamber;
                reloading = false;
            }
            else
            {
                playerData.bullets = Mathf.Floor((playerData.reloadTime - currentCoolDown) / playerData.reloadTime * playerData.bulletsPerChamber);
            }

        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (gameStateSO.isPlayerAlive)
            {
                if (currentCoolDown < 0)//not on cooldown
                {
                    if (playerData.bullets > 0)
                    {
                        Instantiate(shotSFX);
                        reloading = false;
                        playerData.bullets--;
                        currentCoolDown = maxCoolDown;
                        GameObject spawnedBullet = Instantiate(bullet, gunPos.position, Quaternion.identity);
                        Debug.Log("Shot!");
                        playerData.applyRecoil = true;
                    }
                    else
                    {
                        Instantiate(reloadSFX);
                        reloading = true;
                        playerData.bullets = playerData.bulletsPerChamber;
                        currentCoolDown = playerData.reloadTime;
                        Debug.Log("Reloading...");

                    }
                }
            }
        }
    }
}
