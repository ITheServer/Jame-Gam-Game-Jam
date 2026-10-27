using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameStateSO gameStateSO;
    public PlayerSO playerSO;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public SpriteRenderer sr;

    public float movementSpeed;
    public float dashCoolDown;
    public float dashLength;
    public float dashSpeed;

    public bool applyRecoil;
    public float recoilLength;
    public float recoilPower;
    public Vector2 recoilDirection;

    public float invulnerabilityTime;
    public bool isHurt;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Debug.Log("player rb set!");
        }
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Debug.Log("player sr set!");
        }
        applyRecoil = false;

        gameStateSO.isPlayerAlive = true;
        playerSO.maxHealth = 6;
        playerSO.health = playerSO.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
