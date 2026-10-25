using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private GameStateSO gameStateSO;
    [SerializeField] private TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.SetText("Score: "+ gameStateSO.score);
    }
}
