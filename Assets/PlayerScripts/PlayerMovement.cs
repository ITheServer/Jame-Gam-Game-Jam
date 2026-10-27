using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float currentDashCoolDown;
    [SerializeField] private float recoilTimer;
    [SerializeField] private GameObject dashSFX;


    private Vector2 movementDirection;

    // Update is called once per frame
    private void Update()
    {
        currentDashCoolDown += Time.deltaTime;
        if (playerData.applyRecoil)
        {
            playerData.applyRecoil = false;
            recoilTimer = playerData.recoilLength;
        }
    }
    void FixedUpdate()
    {
        if (playerData.gameStateSO.isPlayerAlive)
        {
            if (recoilTimer > 0)
            {
                recoilTimer -= Time.deltaTime;
                playerData.rb.AddForce(playerData.recoilPower * (recoilTimer / playerData.recoilLength) * Time.deltaTime * playerData.recoilDirection, ForceMode2D.Impulse);
            }
            if (currentDashCoolDown < playerData.dashLength)//dashing
            {
                playerData.rb.AddForce(playerData.movementSpeed * Time.deltaTime * playerData.dashSpeed * movementDirection.normalized, ForceMode2D.Impulse);
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
                if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse1)) && currentDashCoolDown >= playerData.dashCoolDown)
                {
                    currentDashCoolDown = 0;
                    Instantiate(dashSFX);
                    playerData.invulnerabilityTime = playerData.dashLength + 0.1f;
                    //extra time accounts for deacceleration
                }
                playerData.rb.AddForce(playerData.movementSpeed * Time.deltaTime * movementDirection.normalized, ForceMode2D.Impulse);
            }
        }
    }
}
