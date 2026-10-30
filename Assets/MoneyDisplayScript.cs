using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplayScript : MonoBehaviour
{
    [SerializeField] private GameStateSO gameStateSO;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float effectLength;
    [SerializeField] private float effectTimer;
    [SerializeField] private float localMoney;
    // Start is called before the first frame update
    void Start()
    {
        localMoney = gameStateSO.money;
        effectTimer = effectLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (localMoney != gameStateSO.money)
        {
            localMoney = gameStateSO.money;
            effectTimer = effectLength / 2;
        }
        effectTimer += Time.deltaTime;
        float sizeIncrease =  (effectLength / effectTimer) / 2;
        transform.localScale = new Vector3(1 + sizeIncrease, 1 + sizeIncrease, 1);
        text.SetText("$"+ gameStateSO.money);
    }
}
