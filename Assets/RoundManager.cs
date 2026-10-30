using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private GameStateSO gameStateSO;
    // Start is called before the first frame update
    void Start()
    {
        gameStateSO.money = 0;
        gameStateSO.roundTimer = 30;
        gameStateSO.roundCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameStateSO.roundTimer -= Time.deltaTime;
        if (gameStateSO.roundTimer < 0)
        {
            //gameStateSO.roundCompleted = true;
        }
    }
}
