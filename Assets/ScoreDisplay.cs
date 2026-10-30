using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private GameStateSO gameStateSO;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float effectLength;
    [SerializeField] private float effectTimer;
    [SerializeField] private float localScore;
    void Start()
    {
        localScore = gameStateSO.score;
        effectTimer = effectLength;
    }

    void Update()
    {
        if (localScore != gameStateSO.score)
        {
            localScore = gameStateSO.score;
            effectTimer = effectLength / 2;
        }
        effectTimer += Time.deltaTime;
        float sizeIncrease = (effectLength / effectTimer) / 2;
        transform.localScale = new Vector3(1 + sizeIncrease, 1 + sizeIncrease, 1);

        text.SetText("Score: "+ gameStateSO.score);
    }
}
