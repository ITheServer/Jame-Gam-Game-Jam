using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarScript : MonoBehaviour
{
    [SerializeField] private Image ir;
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private float fillAmount;
    [SerializeField] private float barType;
    void Update()
    {
        if (barType == 0)
        {
            fillAmount = (float)playerSO.health / (float)playerSO.maxHealth;
        }
        if (barType == 1)
        {
            fillAmount = (float)playerSO.bullets / (float)playerSO.bulletsPerChamber;
        }
        ir.fillAmount = fillAmount;
    }
}
