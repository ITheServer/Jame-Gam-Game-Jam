using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public Vector2 recoilDirection;
    public bool applyRecoil;
    public float recoilPower;
    public float dashMultiplier;

    public int health;
    public int maxHealth;

    public float invulnerabilityTime;
    public bool isHurt;

    public float bullets;
    public float bulletsPerChamber;
    public float shotCooldown;
    public float reloadTime;
    public int bulletsShotAtOnce;
    public float coneOfAccuracy;

    public int currentCharacter;

}
