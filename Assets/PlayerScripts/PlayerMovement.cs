using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashCoolDown;
    [SerializeField] private float currentDashCoolDown;
    [SerializeField] private float recoilTimer;
    [SerializeField] private float recoilLength;
    [SerializeField] private float dashLength;
    [SerializeField] private GameObject dashSFX;
    [SerializeField] private GameStateSO gameStateSO;


    private Vector2 movementDirection;
    private Rigidbody2D rb;
    void Awake()
    {
        playerData.applyRecoil = false;
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Debug.Log("player rb set!");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        currentDashCoolDown += Time.deltaTime;
        if (playerData.applyRecoil)
        {
            playerData.applyRecoil = false;
            recoilTimer = recoilLength;
        }
    }
    void FixedUpdate()
    {
        if (gameStateSO.isPlayerAlive)
        {
            if (recoilTimer > 0)
            {
                recoilTimer -= Time.deltaTime;
                rb.AddForce(playerData.recoilPower * (recoilTimer / recoilLength) * Time.deltaTime * playerData.recoilDirection, ForceMode2D.Impulse);
            }
            if (currentDashCoolDown < dashLength)//dashing
            {
                rb.AddForce(movementSpeed * Time.deltaTime * playerData.dashMultiplier * movementDirection.normalized, ForceMode2D.Impulse);
            }
            else//can only move when not dashing
            {
                movementDirection = Vector2.zero;
                if (Input.GetKey(KeyCode.W))
                {
                    movementDirection.y = 1;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    movementDirection.y = -1;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    movementDirection.x = -1;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    movementDirection.x = 1;
                }
                if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse1)) && currentDashCoolDown >= dashCoolDown)
                {
                    currentDashCoolDown = 0;
                    Instantiate(dashSFX);
                    playerData.invulnerabilityTime = dashLength + 0.1f;
                    //extra time accounts for deacceleration
                }
                rb.AddForce(movementSpeed * Time.deltaTime * movementDirection.normalized, ForceMode2D.Impulse);
            }
        }
    }
}
