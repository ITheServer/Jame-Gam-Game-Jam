using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarScript : MonoBehaviour
{
    [SerializeField] private Image ir;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float fillAmount;
    [SerializeField] private float barType;
    void Update()
    {
        if (barType == 0)
        {
            fillAmount = (float)playerData.health / (float)playerData.maxHealth;
        }
        if (barType == 1)
        {
            fillAmount = (float)playerData.bullets / (float)playerData.bulletsPerChamber;
        }
        ir.fillAmount = fillAmount;
    }
}
