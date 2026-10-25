using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{
    private EnemyData enemyData;
    [SerializeField] private Material damageMaterial;
    private Material baseMaterial;
    void Start()
    {
        enemyData = GetComponent<EnemyData>();
        if (enemyData != null)
        {
            Debug.Log("Enemy data class successfully found.");
        }
        baseMaterial = enemyData.sr.material;
    }

    // Update is called once per frame
    void Update()
    {
        enemyData.damageTimer -= Time.deltaTime;
        if (enemyData.damageTimer > 0)
        {
            enemyData.sr.material = damageMaterial;
        }
        else
        {
            enemyData.sr.material = baseMaterial;
        }
    }
}
