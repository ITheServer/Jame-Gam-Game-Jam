using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private EnemyData enemyData;
    [SerializeField] private float maxCoolDown;
    [SerializeField] private int bulletsPerChamber;
    [SerializeField] private int bulletsLeft;
    [SerializeField] private float reloadTime;
    [SerializeField] private int bulletsShotAtOnce;
    [SerializeField] private float coneOfAccuracy;
    [SerializeField] private GameObject shotSFX;
    [SerializeField] private GameObject spawnSFX;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnSFX);
        enemyData = GetComponent<EnemyData>();
        if (enemyData != null)
        {
            Debug.Log("Enemy data class successfully found.");
        }
        enemyData.currentCoolDown = reloadTime * Random.Range(0.9f, 1.1f) + maxCoolDown;
        bulletsLeft = bulletsPerChamber;
    }

    // Update is called once per frame
    void Update()
    {
        enemyData.currentCoolDown -= Time.deltaTime;
        if (enemyData.currentCoolDown < 0)//not on cooldown
        {
            if (bulletsLeft > 0)
            {
                enemyData.currentCoolDown = maxCoolDown;
                bulletsLeft -= bulletsShotAtOnce;
                for (int i = 0; i < bulletsShotAtOnce; i++)
                {
                    GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                    EnemyBullet enemyBullet = spawnedBullet.GetComponent<EnemyBullet>();
                    enemyBullet.enemyData = enemyData;//pass on current enemy data to bullet.
                    Vector2 bulletDirection = (enemyData.player.transform.position - transform.position).normalized;
                    var rotation = Quaternion.AngleAxis((coneOfAccuracy / bulletsShotAtOnce * i) - coneOfAccuracy / bulletsShotAtOnce, Vector3.forward).normalized;
                    Debug.Log(rotation);
                    enemyBullet.moveDirection = (rotation * bulletDirection).normalized;
                }
                Instantiate(shotSFX);
                enemyData.recoilDirection = -(enemyData.player.transform.position - transform.position).normalized;
                enemyData.applyRecoil = true;
            }
            else
            {
                bulletsLeft = bulletsPerChamber;
                enemyData.currentCoolDown = reloadTime * Random.Range(0.9f,1.1f);
            }
        }
    }
}
