using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnRoundEnd : MonoBehaviour
{
    [SerializeField] private GameStateSO gameStateSO;
    void Update()
    {
        if (gameStateSO.roundCompleted || !gameStateSO.isPlayerAlive)
        {
            Destroy(gameObject);
        }
    }
}
