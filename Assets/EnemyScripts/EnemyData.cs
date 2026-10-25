using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public Vector2 recoilDirection;
    public bool applyRecoil;
    public float recoilPower;
    public float currentCoolDown;
    public int health;
    public int maxHealth;
    public GameObject player;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float damageTimer;

    private void Awake()
    {
        health = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
}
