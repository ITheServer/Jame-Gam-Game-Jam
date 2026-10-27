using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerProjectileSpawner : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float currentCoolDown;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunPos;
    [SerializeField] private GameObject shotSFX;
    [SerializeField] private AudioSource reloadSFX;

    private bool reloading;
    // Start is called before the first frame update
    void Awake()
    {
        playerData.playerSO.bullets = playerData.playerSO.bulletsPerChamber;
        reloading = false;
        currentCoolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;
            currentCoolDown = playerData.playerSO.reloadTime * (1 - playerData.playerSO.bullets / playerData.playerSO.bulletsPerChamber);
            playerData.playerSO.bullets = playerData.playerSO.bulletsPerChamber;
            Debug.Log("Reloading...");
        }
        if (reloading)
        {
            if (!reloadSFX.isPlaying)
            {
                reloadSFX.Play();
            }
            if (currentCoolDown < 0)//done reloading
            {
                playerData.playerSO.bullets = playerData.playerSO.bulletsPerChamber;
                reloading = false;
            }
            else
            {
                playerData.playerSO.bullets = Mathf.Floor((playerData.playerSO.reloadTime - currentCoolDown) / playerData.playerSO.reloadTime * playerData.playerSO.bulletsPerChamber);
            }

        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (playerData.gameStateSO.isPlayerAlive)
            {
                if (currentCoolDown < 0)//not on cooldown
                {
                    if (playerData.playerSO.bullets > 0)
                    {
                        Instantiate(shotSFX);
                        reloading = false;
                        currentCoolDown = playerData.playerSO.shotCooldown;
                        for (int i = 0; i < playerData.playerSO.bulletsShotAtOnce; i++)
                        {
                            playerData.playerSO.bullets--;
                            //Projectile playerBullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Projectile>();
                            //playerBullet.playerData = playerData;//pass on current player data to bullet.

                            GameObject instantiatedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                            Projectile playerBullet = instantiatedBullet.GetComponent<Projectile>();
                            playerBullet.playerData = playerData;//pass on current player data to bullet.

                            Vector3 mousePos = Input.mousePosition;
                            Vector3 bulletDirection = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
                            bulletDirection.z = 0;
                            bulletDirection = bulletDirection.normalized;//calculate bullet direction based on mouse position
                            Debug.Log(bulletDirection);

                            playerData.recoilDirection = -bulletDirection;
                            playerData.applyRecoil = true;//get recoil

                            //if multiple bullets are spawned, calculate offset for each bullet based on accuracy
                            if (playerData.playerSO.bulletsShotAtOnce > 1)
                            {
                                var rotation = Quaternion.AngleAxis((playerData.playerSO.coneOfAccuracy / playerData.playerSO.bulletsShotAtOnce * i) - playerData.playerSO.coneOfAccuracy / 2, Vector3.forward).normalized;
                                Debug.Log(rotation);
                                playerBullet.moveDirection = (rotation * bulletDirection).normalized;
                            }
                            else
                            {
                                playerBullet.moveDirection = bulletDirection;
                            }
                        }
                        Debug.Log("Shot!");

                    }
                    else
                    {
                        reloading = true;
                        currentCoolDown = playerData.playerSO.reloadTime;
                        Debug.Log("Reloading...");

                    }
                }
            }
        }
    }
}
