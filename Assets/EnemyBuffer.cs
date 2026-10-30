using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffer : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private float spawnBuffer;
    [SerializeField] private float currentBuffer;

    // Start is called before the first frame update
    void Awake()
    {
        currentBuffer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentBuffer += Time.deltaTime;
        float scale = Mathf.Sin(currentBuffer * currentBuffer * 10) / 5 * currentBuffer;
        transform.localScale = new Vector3(1 + scale, 1 + scale, 1);
        if (currentBuffer > spawnBuffer)
        {
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
