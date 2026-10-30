using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> popcornEnemies;
    [SerializeField] private List<GameObject> tankyEnemies;

    [SerializeField] private GameStateSO gameStateSO;
    [SerializeField] private float popcornSpawnCoolDown;
    [SerializeField] private float tankSpawnCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        gameStateSO.survivalTimer = 0;
        popcornSpawnCoolDown = 0;
        tankSpawnCoolDown = 0;
        SpawnPopcornEnemy();
        SpawnPopcornEnemy();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateSO.isPlayerAlive && !gameStateSO.roundCompleted)
        {
            gameStateSO.survivalTimer += Time.deltaTime;
            gameStateSO.difficultyScaling = gameStateSO.survivalTimer / 300 + 1;
            popcornSpawnCoolDown -= Time.deltaTime;
            tankSpawnCoolDown -= Time.deltaTime;
        }
        if (popcornSpawnCoolDown < 0)
        {
            SpawnPopcornEnemy();
        }
        if (tankSpawnCoolDown < 0)
        {
            SpawnTankyEnemy();
        }
    }

    private void SpawnPopcornEnemy()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        int chosenEnemy = Random.Range(0, popcornEnemies.Count);
        Instantiate(popcornEnemies[chosenEnemy], randomPosition, Quaternion.identity);
        popcornSpawnCoolDown = 3f / gameStateSO.difficultyScaling; 
    }
    private void SpawnTankyEnemy()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        int chosenEnemy = Random.Range(0, Mathf.Min(tankyEnemies.Count,Mathf.FloorToInt(gameStateSO.survivalTimer / 60) + 1));
        Instantiate(tankyEnemies[chosenEnemy], randomPosition, Quaternion.identity);
        tankSpawnCoolDown = 10f / gameStateSO.difficultyScaling;
    }
}
